using System.Text.Json;
using MtgTop8;

namespace UsageData;

/// <summary>The in-memory dataset shared by all pages, plus a JSON cache in %AppData%.</summary>
public sealed class AppState
{
    private static readonly JsonSerializerOptions Json = new() { WriteIndented = false };

    public static string CachePath { get; } = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MtgTop8Explorer", "decks.json");

    public List<DeckDetail> Decks { get; } = new();

    public event EventHandler? DataChanged;

    /// <summary>Adds decks not already present (matched by deck id). Returns how many were new.</summary>
    public int Add(IEnumerable<DeckDetail> decks)
    {
        var known = Decks.Select(d => d.Summary.DeckId).ToHashSet();
        var added = 0;
        foreach (var d in decks)
            if (known.Add(d.Summary.DeckId)) { Decks.Add(d); added++; }
        if (added > 0) DataChanged?.Invoke(this, EventArgs.Empty);
        return added;
    }

    public void Clear()
    {
        Decks.Clear();
        DataChanged?.Invoke(this, EventArgs.Empty);
    }

    public void Save()
    {
        Directory.CreateDirectory(Path.GetDirectoryName(CachePath)!);
        File.WriteAllText(CachePath, JsonSerializer.Serialize(Decks, Json));
    }

    public int Load()
    {
        if (!File.Exists(CachePath)) return 0;
        var list = JsonSerializer.Deserialize<List<DeckDetail>>(File.ReadAllText(CachePath), Json) ?? new();
        Decks.Clear();
        Decks.AddRange(list);
        DataChanged?.Invoke(this, EventArgs.Empty);
        return Decks.Count;
    }
}
