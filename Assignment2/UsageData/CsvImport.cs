using System.Text;
using System.Text.RegularExpressions;
using MtgTop8;

namespace UsageData;

//Reads back the CSVs written by cref="CsvExporter" (either file) into decks.
public static class CsvImport
{
    private static readonly string[] Required =
        { "Format", "EventId", "EventName", "EventDate", "Place", "DeckId", "DeckName", "Player", "Board", "Card", "Quantity" };

    public static List<DeckDetail> Read(string path)
    {
        var lines = File.ReadAllLines(path, Encoding.UTF8);
        if (lines.Length < 2) return new();

        var header = Split(lines[0]);
        var idx = Required.ToDictionary(n => n, n => Array.FindIndex(header, h => h.Trim().Equals(n, StringComparison.OrdinalIgnoreCase)));
        var missing = idx.Where(kv => kv.Value < 0).Select(kv => kv.Key).ToList();
        if (missing.Count > 0)
            throw new InvalidDataException("Not a MtgTop8Scraper CSV. Missing columns: " + string.Join(", ", missing));

        var maxIdx = idx.Values.Max();
        var map = new Dictionary<int, (DeckSummary Summary, List<DeckCard> Cards)>();
        var order = new List<int>();

        for (var i = 1; i < lines.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(lines[i])) continue;
            var f = Split(lines[i]);
            if (f.Length <= maxIdx) continue;

            var deckId = int.Parse(f[idx["DeckId"]]);
            if (!map.TryGetValue(deckId, out var entry))
            {
                var placeText = f[idx["Place"]];
                var pm = Regex.Match(placeText, @"^\d+");
                var summary = new DeckSummary(
                    deckId, int.Parse(f[idx["EventId"]]), f[idx["Format"]], f[idx["EventName"]],
                    string.IsNullOrWhiteSpace(f[idx["EventDate"]]) ? null : f[idx["EventDate"]],
                    pm.Success ? int.Parse(pm.Value) : 999, placeText, f[idx["DeckName"]], f[idx["Player"]]);
                entry = (summary, new List<DeckCard>());
                map[deckId] = entry;
                order.Add(deckId);
            }
            entry.Cards.Add(new DeckCard(
                f[idx["Card"]], int.Parse(f[idx["Quantity"]]),
                f[idx["Board"]].Equals("Sideboard", StringComparison.OrdinalIgnoreCase)));
        }
        return order.Select(id => new DeckDetail(map[id].Summary, map[id].Cards)).ToList();
    }

    private static string[] Split(string line)
    {
        var fields = new List<string>();
        var sb = new StringBuilder();
        var quoted = false;
        for (var i = 0; i < line.Length; i++)
        {
            var c = line[i];
            if (quoted)
            {
                if (c == '"')
                {
                    if (i + 1 < line.Length && line[i + 1] == '"') { sb.Append('"'); i++; }
                    else quoted = false;
                }
                else sb.Append(c);
            }
            else if (c == '"') quoted = true;
            else if (c == ',') { fields.Add(sb.ToString()); sb.Clear(); }
            else sb.Append(c);
        }
        fields.Add(sb.ToString());
        return fields.ToArray();
    }
}
