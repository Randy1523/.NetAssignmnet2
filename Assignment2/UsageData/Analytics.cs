using System.Runtime.InteropServices;
using MtgTop8;

namespace UsageData;

public enum BoardScope { Main, Sideboard, Both }

//name="Card"Partial, case-insensitive card name (null = any).
// name="Format"mtgtop8 format code (null = all formats).
public sealed record Filter(string? Card, string? Format, BoardScope Board, bool HideBasics);

public sealed record CardStat(string Card, int Decks, double DeckShare, int TotalCopies, double AvgCopies);
public sealed record ArchetypeUsage(string Format, string Archetype, int DecksWithCard, int ArchetypeDecks, double Share);
public sealed record CopyUsage(int Copies, int Decks, double Share);
public sealed record PairStat(string CardA, string CardB, int Together, double ShareOfDecks, double BInADecks, double AInBDecks, double Lift);

public static class Analytics
{
    private static readonly HashSet<string> Basics = new(StringComparer.OrdinalIgnoreCase)
    {
        "Plains", "Island", "Swamp", "Mountain", "Forest", "Wastes",
        "Snow-Covered Plains", "Snow-Covered Island", "Snow-Covered Swamp", "Snow-Covered Mountain", "Snow-Covered Forest"
    };

    public static bool IsBasic(string name) => Basics.Contains(name);

    public static List<DeckDetail> ByFormat(IEnumerable<DeckDetail> decks, string? format)
        => format is null
            ? decks.ToList()
            : decks.Where(d => d.Summary.FormatCode.Equals(format, StringComparison.OrdinalIgnoreCase)).ToList();

    //Distinct card name -> copies, for the board scope and basic-land setting.
    private static Dictionary<string, int> Copies(DeckDetail d, BoardScope board, bool hideBasics)
    {
        var r = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        foreach (var c in d.Cards)
        {
            if (board == BoardScope.Main && c.IsSideboard) continue;
            if (board == BoardScope.Sideboard && !c.IsSideboard) continue;
            if (hideBasics && IsBasic(c.CardName)) continue;
            r.TryGetValue(c.CardName, out var n);
            r[c.CardName] = n + c.Quantity;
        }
        return r;
    }

    //Card usage

    public static List<CardStat> CardUsage(IReadOnlyList<DeckDetail> all, Filter f)
    {
        var decks = ByFormat(all, f.Format);
        var stats = new Dictionary<string, (int Decks, int Copies)>(StringComparer.OrdinalIgnoreCase);
        foreach (var d in decks)
            foreach (var kv in Copies(d, f.Board, f.HideBasics))
            {
                stats.TryGetValue(kv.Key, out var s);
                stats[kv.Key] = (s.Decks + 1, s.Copies + kv.Value);
            }

        return stats
            .Where(kv => f.Card is null || kv.Key.Contains(f.Card, StringComparison.OrdinalIgnoreCase))
            .Select(kv => new CardStat(kv.Key, kv.Value.Decks, (double)kv.Value.Decks / decks.Count,
                                       kv.Value.Copies, (double)kv.Value.Copies / kv.Value.Decks))
            .OrderByDescending(x => x.Decks).ThenBy(x => x.Card, StringComparer.OrdinalIgnoreCase)
            .ToList();
    }

    public static (List<ArchetypeUsage> Archetypes, List<CopyUsage> Copies) CardDetails(
        IReadOnlyList<DeckDetail> all, Filter f, string card)
    {
        var decks = ByFormat(all, f.Format);
        var totals = decks.GroupBy(d => (d.Summary.FormatCode, d.Summary.DeckName)).ToDictionary(g => g.Key, g => g.Count());

        var withCard = new List<(DeckDetail Deck, int Copies)>();
        foreach (var d in decks)
            if (Copies(d, f.Board, f.HideBasics).TryGetValue(card, out var n)) withCard.Add((d, n));

        var archetypes = withCard
            .GroupBy(x => (x.Deck.Summary.FormatCode, x.Deck.Summary.DeckName))
            .Select(g => new ArchetypeUsage(Formats.Name(g.Key.FormatCode), g.Key.DeckName, g.Count(),
                                            totals[g.Key], (double)g.Count() / totals[g.Key]))
            .OrderByDescending(a => a.DecksWithCard).ThenByDescending(a => a.Share)
            .ToList();

        var copies = withCard
            .GroupBy(x => x.Copies).OrderBy(g => g.Key)
            .Select(g => new CopyUsage(g.Key, g.Count(), (double)g.Count() / withCard.Count))
            .ToList();

        return (archetypes, copies);
    }

    // ---------- Pairings ----------


    // Cards that appear in the same deck.
    // the most common pairs overall.

    public static List<PairStat> Pairs(IReadOnlyList<DeckDetail> all, Filter f, int minTogether, int maxRows = 1000)
    {
        var decks = ByFormat(all, f.Format);

        var ids = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        var names = new List<string>();
        var deckIds = new List<int[]>(decks.Count);

        foreach (var d in decks)
        {
            var set = new SortedSet<int>();
            foreach (var name in Copies(d, f.Board, f.HideBasics).Keys)
            {
                if (!ids.TryGetValue(name, out var id)) { id = names.Count; ids[name] = id; names.Add(name); }
                set.Add(id);
            }
            deckIds.Add(set.ToArray());
        }

        var single = new int[names.Count];
        foreach (var arr in deckIds) foreach (var id in arr) single[id]++;

        HashSet<int>? match = null;
        if (f.Card is not null)
            match = names.Select((nm, i) => (nm, i))
                         .Where(x => x.nm.Contains(f.Card, StringComparison.OrdinalIgnoreCase))
                         .Select(x => x.i).ToHashSet();

        var counts = new Dictionary<long, int>();
        //probably not the fastest computing time, but works ok for the number of decks being parsed. Counting for card matches.
        foreach (var arr in deckIds)
        {
            if (match is null)
            {
                for (var i = 0; i < arr.Length; i++)
                    for (var j = i + 1; j < arr.Length; j++)
                        Bump(counts, ((long)arr[i] << 32) | (uint)arr[j]);
            }
            else
            {
                foreach (var a in arr)
                {
                    if (!match.Contains(a)) continue;
                    foreach (var b in arr)
                        if (b != a) Bump(counts, ((long)a << 32) | (uint)b);
                }
            }
        }

        var n = decks.Count;
        var rows = new List<PairStat>();
        foreach (var (key, c) in counts)
        {
            if (c < minTogether) continue;
            var a = (int)(key >> 32);
            var b = (int)(key & 0xFFFFFFFFL);
            rows.Add(new PairStat(names[a], names[b], c, (double)c / n,
                                  (double)c / single[a], (double)c / single[b],
                                  (double)c * n / ((double)single[a] * single[b])));
        }
        return rows.OrderByDescending(r => r.Together).ThenByDescending(r => r.Lift).Take(maxRows).ToList();

        static void Bump(Dictionary<long, int> d, long key)
        {
            ref var slot = ref CollectionsMarshal.GetValueRefOrAddDefault(d, key, out _);
            slot++;
        }
    }

    //Top players

    //Top N players per format, scored by placement points (default 1st = 32 ... 32nd = 1).
    public static List<PlayerRanking> TopPlayers(IReadOnlyList<DeckDetail> all, string? format, int perFormat = 10)
    {
        static int Points(int place) => Math.Max(0, 33 - place);
        var result = new List<PlayerRanking>();
        //ordering results, by format and group, gives data on placing and such.
        foreach (var fg in ByFormat(all, format).GroupBy(d => d.Summary.FormatCode).OrderBy(g => g.Key))
        {
            var ranked = fg.Where(d => !string.IsNullOrWhiteSpace(d.Summary.Player))
                .GroupBy(d => d.Summary.Player.Trim(), StringComparer.OrdinalIgnoreCase)
                .Select(pg => new
                {
                    Player = pg.Key,
                    Score = pg.Sum(d => Points(d.Summary.Place)),
                    Best = pg.Min(d => d.Summary.Place),
                    Decks = pg.OrderBy(d => d.Summary.Place).ToList()
                })
                .OrderByDescending(x => x.Score).ThenBy(x => x.Best).ThenByDescending(x => x.Decks.Count)
                .ThenBy(x => x.Player, StringComparer.OrdinalIgnoreCase)
                .Take(perFormat);
            //rank players and return them in order
            var rank = 1;
            foreach (var x in ranked)
                result.Add(new PlayerRanking(fg.Key, rank++, x.Player, x.Score, x.Decks));
        }
        return result;
    }
}
