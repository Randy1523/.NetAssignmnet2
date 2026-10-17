namespace MtgTop8;

public sealed class ScrapeOptions
{
    //mtgtop8 format codes = the "categories" of events (Standard, Modern, ...)
    public IReadOnlyList<string> FormatCodes { get; init; } =
        new[] { "ST", "PI", "MO", "LE", "VI", "PAU", "cEDH", "EDH", "PREM" };

    //How many of the most recent events to scan per format.
    public int MaxEventsPerFormat { get; init; } = 10;

    //Cap on decks read per event (best placements first). Use int.MaxValue for "all listed"
    public int MaxDecksPerEvent { get; init; } = int.MaxValue;

    public int TopPlayersPerFormat { get; init; } = 10;

    // Points awarded for a placement (first number of "5-8" = 5). Default: 1st = 32 ... 32nd = 1.
    public Func<int, int> PlacementPoints { get; init; } = place => Math.Max(0, 33 - place);

    //filter, e.g. e => e.Date is not null &amp;&amp; string.CompareOrdinal(e.Date, "2026-10-01") >= 0.
    public Func<EventInfo, bool>? EventFilter { get; init; }
}

public sealed class MtgTop8Scraper : IAsyncDisposable
{
    private readonly IPageFetcher _fetcher;
    private readonly Dictionary<int, IReadOnlyList<DeckCard>> _cardCache = new();

    // name="fetcher" Defaults to cref="HttpPageFetcher" pass a cref="PuppeteerPageFetcher" for a real browser. (Don't do this!!!, but hey the option is there just in case)
    public MtgTop8Scraper(IPageFetcher? fetcher = null) => _fetcher = fetcher ?? new HttpPageFetcher();

    public async Task<ScrapeResult> ScrapeAsync(
        ScrapeOptions? options = null, IProgress<string>? progress = null, CancellationToken ct = default)
    {
        options ??= new ScrapeOptions();
        var result = new ScrapeResult();

        foreach (var code in options.FormatCodes)
        {
            progress?.Report($"[{code}] listing events...");
            var events = await GetRecentEventsAsync(code, options, ct);
            var formatDecks = new List<DeckDetail>();

            foreach (var listed in events)
            {
                try
                {
                    var html = await _fetcher.GetHtmlAsync(Urls.Event(listed.Id, code), ct);
                    var (name, date) = MtgTop8Parser.ParseEventHeader(html);
                    var ev = listed with { Name = name ?? listed.Name, Date = date ?? listed.Date };

                    var summaries = MtgTop8Parser.ParseEventDecks(html, ev).Take(options.MaxDecksPerEvent).ToList();
                    progress?.Report($"[{code}] {ev.Name} (#{ev.Id}): {summaries.Count} decks");

                    foreach (var s in summaries)
                    {
                        try { formatDecks.Add(new DeckDetail(s, await GetCardsAsync(s.DeckId, ct))); }
                        catch (Exception ex) when (ex is HttpRequestException or TaskCanceledException && !ct.IsCancellationRequested)
                        {
                            progress?.Report($"  ! deck {s.DeckId} skipped: {ex.Message}");
                        }
                    }
                }
                catch (HttpRequestException ex)
                {
                    progress?.Report($"  ! event {listed.Id} skipped: {ex.Message}");
                }
            }

            result.Decks.AddRange(formatDecks);
            result.TopPlayers.AddRange(RankPlayers(code, formatDecks, options));
        }
        return result;
    }

    private async Task<List<EventInfo>> GetRecentEventsAsync(string code, ScrapeOptions o, CancellationToken ct)
    {
        const int maxPages = 20;
        var firstHtml = await _fetcher.GetHtmlAsync(Urls.Format(code), ct);
        var events = MtgTop8Parser.ParseEventList(firstHtml, code);
        var template = MtgTop8Parser.FindPageTemplate(firstHtml);

        for (var page = 2; template is not null && page <= maxPages && Count(events, o) < o.MaxEventsPerFormat; page++)
        {
            var href = System.Text.RegularExpressions.Regex.Replace(template, @"cp=2\b", $"cp={page}");
            var more = MtgTop8Parser.ParseEventList(await _fetcher.GetHtmlAsync(Urls.Absolute(href), ct), code)
                                    .Where(e => events.All(x => x.Id != e.Id)).ToList();
            if (more.Count == 0) break;
            events.AddRange(more);
        }
        return events.Where(e => o.EventFilter?.Invoke(e) ?? true).Take(o.MaxEventsPerFormat).ToList();

        static int Count(List<EventInfo> list, ScrapeOptions opt) => list.Count(e => opt.EventFilter?.Invoke(e) ?? true);
    }

    private async Task<IReadOnlyList<DeckCard>> GetCardsAsync(int deckId, CancellationToken ct)
    {
        if (_cardCache.TryGetValue(deckId, out var cached)) return cached;
        var text = await _fetcher.GetTextAsync(Urls.DeckExport(deckId), ct);
        var cards = MtgTop8Parser.ParseDecList(text);
        _cardCache[deckId] = cards;
        return cards;
    }

    private static IEnumerable<PlayerRanking> RankPlayers(string code, List<DeckDetail> decks, ScrapeOptions o)
        => decks.Where(d => !string.IsNullOrWhiteSpace(d.Summary.Player))
                .GroupBy(d => d.Summary.Player.Trim(), StringComparer.OrdinalIgnoreCase)
                .Select(g => new
                {
                    Player = g.Key,
                    Score = g.Sum(d => o.PlacementPoints(d.Summary.Place)),
                    Best = g.Min(d => d.Summary.Place),
                    Decks = g.OrderBy(d => d.Summary.Place).ToList()
                })
                .OrderByDescending(x => x.Score)
                .ThenBy(x => x.Best)
                .ThenByDescending(x => x.Decks.Count)
                .ThenBy(x => x.Player, StringComparer.OrdinalIgnoreCase)
                .Take(o.TopPlayersPerFormat)
                .Select((x, i) => new PlayerRanking(code, i + 1, x.Player, x.Score, x.Decks));

    public ValueTask DisposeAsync() => _fetcher.DisposeAsync();
}
