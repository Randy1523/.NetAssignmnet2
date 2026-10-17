using System.Globalization;
using System.Text.RegularExpressions;
using AngleSharp.Dom;
using AngleSharp.Html.Parser;

namespace MtgTop8;


// just parsing logic (no network). All site-specific selectors live here.

public static class MtgTop8Parser
{
    private static readonly HtmlParser Html = new();

    // event?e=92315&f=LE            (event page)
    private static readonly Regex EventLinkRx = new(@"event\?e=(\d+)&f=(\w+)$", RegexOptions.Compiled);
    // one deck of an event: "event?e=1&d=2&f=LE", "?e=1&d=2&f=LE", Url grafting
    private static readonly Regex DeckLinkRx = new(@"^(?:https?://[^/]+/)?(?:event)?\?(?=.*\be=(\d+))(?=.*\bd=(\d+))", RegexOptions.Compiled);
    private static readonly Regex PlaceRx = new(@"^\s*(\d+)(?:\s*-\s*(\d+))?", RegexOptions.Compiled);
    private static readonly Regex DateRx = new(@"\b(\d{2}/\d{2}/\d{2})\b", RegexOptions.Compiled);
    private static readonly Regex EventDateRx = new(@"\d+\s+players\s*-\s*(\d{2}/\d{2}/\d{2})", RegexOptions.Compiled);
    // "4 [UL] Goblin Dude"  /  "SB:  2 [CMD] Flusterstorm"  /  "1 Island"
    private static readonly Regex DecLineRx = new(@"^(SB:\s*)?(\d+)\s+(?:\[[^\]]*\]\s*)?(.+?)\s*$", RegexOptions.Compiled);

    private static string Clean(string? s) => Regex.Replace(s ?? "", @"\s+", " ").Trim();

    //Events linked from a format page (major events + latest events).
    public static List<EventInfo> ParseEventList(string html, string formatCode)
    {
        var doc = Html.ParseDocument(html);
        var seen = new HashSet<int>();
        var events = new List<EventInfo>();

        foreach (var a in doc.QuerySelectorAll("a[href]"))
        {
            var m = EventLinkRx.Match(a.GetAttribute("href") ?? "");
            if (!m.Success || !m.Groups[2].Value.Equals(formatCode, StringComparison.OrdinalIgnoreCase)) continue;

            var name = Clean(a.TextContent);
            if (name.Length == 0) continue;                                   // thumbnail / icon links
            if (name.StartsWith("The Decks to Beat", StringComparison.OrdinalIgnoreCase) ||
                name.StartsWith("The Rogue Corner", StringComparison.OrdinalIgnoreCase)) continue; // editorial pages

            var id = int.Parse(m.Groups[1].Value);
            if (!seen.Add(id)) continue;                                      // first anchor = event name, later = venue

            var date = DateRx.Match(a.Closest("tr")?.TextContent ?? "");
            events.Add(new EventInfo(id, formatCode, name, date.Success ? NormalizeDate(date.Groups[1].Value) : null));
        }
        return events;
    }

    //Returns the href of the link for page 2, used as a template for other pages!
    public static string? FindPageTemplate(string formatPageHtml)
    {
        var doc = Html.ParseDocument(formatPageHtml);
        return doc.QuerySelectorAll("a[href]")
                  .Select(a => a.GetAttribute("href") ?? "")
                  .FirstOrDefault(h => Regex.IsMatch(h, @"[?&]cp=2\b"));
    }

    public static (string? Name, string? Date) ParseEventHeader(string html)
    {
        var doc = Html.ParseDocument(html);

        // Legacy event - Championship @ Venue (City, Country) @ mtgtop8.com
        string? name = null;
        var title = Clean(doc.Title);
        var idx = title.IndexOf(" event - ", StringComparison.Ordinal);
        if (idx >= 0)
        {
            name = title[(idx + " event - ".Length)..];
            const string suffix = " @ mtgtop8.com";
            if (name.EndsWith(suffix, StringComparison.Ordinal)) name = name[..^suffix.Length];
        }

        var body = Clean(doc.Body?.TextContent);
        var d = EventDateRx.Match(body);
        if (!d.Success) d = DateRx.Match(body);
        return (name, d.Success ? NormalizeDate(d.Groups[1].Value) : null);
    }


    // Decks (placement, archetype, player) listed on an event page, best placement first.
    // Reads the page in document order, which on the standings list is: placement text,
    // thumbnail link, deck-name link, player link. It does not depend on how rows are wrapped.

    public static List<DeckSummary> ParseEventDecks(string html, EventInfo ev)
    {
        var doc = Html.ParseDocument(html);
        var decks = new List<DeckSummary>();
        var seen = new HashSet<int>();
        if (doc.Body is null) return decks;

        string? lastPlace = null;
        (int Id, string Name, string Place)? pending = null;

        void Flush(string player)
        {
            if (pending is not { } p) return;
            seen.Add(p.Id);
            var pm = PlaceRx.Match(p.Place);
            decks.Add(new DeckSummary(p.Id, ev.Id, ev.FormatCode, ev.Name, ev.Date,
                pm.Success ? int.Parse(pm.Groups[1].Value) : 999,
                pm.Success ? pm.Value.Replace(" ", "") : "",
                p.Name, player));
            pending = null;
        }

        foreach (var node in doc.Body.Descendants())
        {
            if (node is IText text)
            {
                if (text.ParentElement?.TagName is "A" or "SCRIPT" or "STYLE") continue;
                var s = Clean(text.Data);
                if (Regex.IsMatch(s, @"^\d+(\s*-\s*\d+)?$")) lastPlace = s;   // "1", "2", "3-4", "5-8"
                continue;
            }

            if (node is not IElement { TagName: "A" } a) continue;
            var href = a.GetAttribute("href") ?? "";

            if (href.Contains("player=", StringComparison.OrdinalIgnoreCase))
            {
                if (pending is not null) Flush(Clean(a.TextContent));
                continue;
            }

            var m = DeckLinkRx.Match(href);
            if (!m.Success || int.Parse(m.Groups[1].Value) != ev.Id) continue;

            var name = Clean(a.TextContent);
            if (name.Length == 0 || name == "→") continue;                       // thumbnail / arrow links

            var deckId = int.Parse(m.Groups[2].Value);
            if (seen.Contains(deckId) || (pending is { } cur && cur.Id == deckId)) continue;

            if (pending is not null) Flush("");                                  // previous deck had no player link
            pending = (deckId, name, lastPlace ?? "");
            lastPlace = null;
        }
        Flush("");

        return decks.OrderBy(d => d.Place).ThenBy(d => d.DeckId).ToList();
    }

    //Parses mtgtop8's plain-text .dec export. Double lines are merged
    public static List<DeckCard> ParseDecList(string text)
    {
        var totals = new Dictionary<(string Name, bool Side), int>();
        var order = new List<(string Name, bool Side)>();

        foreach (var raw in text.Split('\n'))
        {
            var line = raw.Trim();
            if (line.Length == 0 || line.StartsWith("//")) continue;

            var m = DecLineRx.Match(line);
            if (!m.Success) continue;

            var key = (m.Groups[3].Value, m.Groups[1].Success);
            var qty = int.Parse(m.Groups[2].Value);
            if (totals.TryAdd(key, qty)) order.Add(key);
            else totals[key] += qty;
        }
        return order.Select(k => new DeckCard(k.Name, totals[k], k.Side)).ToList();
    }

    private static string NormalizeDate(string ddMMyy)
        => DateTime.TryParseExact(ddMMyy, "dd/MM/yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var d)
            ? d.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
            : ddMMyy;
}
