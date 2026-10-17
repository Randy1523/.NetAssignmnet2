using System.Text;

namespace MtgTop8;

public static class CsvExporter
{
    private const string DeckColumns =
        "Format,EventId,EventName,EventDate,Place,DeckId,DeckName,Player,Board,Card,Quantity,DeckUrl";

    //Every card of every deck, grouped deck by deck (main deck first, then sideboard, A-Z ordere).
    public static void WriteAllDeckCards(string path, IEnumerable<DeckDetail> decks)
    {
        using var w = Open(path);
        w.WriteLine(DeckColumns);
        foreach (var d in OrderDecks(decks))
            foreach (var line in DeckLines(d))
                w.WriteLine(line);
    }

    //Top players per format, with every deck they played and every card in those decks.
    public static void WriteTopPlayers(string path, IEnumerable<PlayerRanking> rankings)
    {
        using var w = Open(path);
        w.WriteLine("PlayerRank,PlayerScore," + DeckColumns);
        foreach (var r in rankings.OrderBy(r => r.FormatCode, StringComparer.OrdinalIgnoreCase).ThenBy(r => r.Rank))
            foreach (var d in r.Decks)
                foreach (var line in DeckLines(d))
                    w.WriteLine($"{r.Rank},{r.Score},{line}");
    }

    public static void WriteAll(string directory, ScrapeResult result)
    {
        Directory.CreateDirectory(directory);
        WriteAllDeckCards(Path.Combine(directory, "all_deck_cards.csv"), result.Decks);
        WriteTopPlayers(Path.Combine(directory, "top_players_decks_cards.csv"), result.TopPlayers);
    }

    private static IEnumerable<DeckDetail> OrderDecks(IEnumerable<DeckDetail> decks)
        => decks.OrderBy(d => d.Summary.FormatCode, StringComparer.OrdinalIgnoreCase)
                .ThenByDescending(d => d.Summary.EventId)
                .ThenBy(d => d.Summary.Place)
                .ThenBy(d => d.Summary.DeckId);

    private static IEnumerable<string> DeckLines(DeckDetail d)
    {
        var s = d.Summary;
        foreach (var c in d.Cards.OrderBy(c => c.IsSideboard).ThenBy(c => c.CardName, StringComparer.OrdinalIgnoreCase))
        {
            yield return string.Join(',', new[]
            {
                Esc(s.FormatCode), s.EventId.ToString(), Esc(s.EventName), Esc(s.EventDate),
                Esc(s.PlaceText), s.DeckId.ToString(), Esc(s.DeckName), Esc(s.Player),
                c.IsSideboard ? "Sideboard" : "Main", Esc(c.CardName), c.Quantity.ToString(), Esc(s.Url)
            });
        }
    }

    private static StreamWriter Open(string path)
        => new(path, false, new UTF8Encoding(encoderShouldEmitUTF8Identifier: true)); // BOM so Excel reads propperly

    private static string Esc(string? v)
    {
        v ??= "";
        return v.IndexOfAny(new[] { ',', '"', '\r', '\n' }) >= 0 ? $"\"{v.Replace("\"", "\"\"")}\"" : v;
    }
}
