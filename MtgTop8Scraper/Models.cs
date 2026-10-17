namespace MtgTop8;

//An event listed on a format page (e.g. "MTGO Challenge 32").
public sealed record EventInfo(int Id, string FormatCode, string Name, string? Date);

//One row of an event's standings, a deck, its user and its placement.
public sealed record DeckSummary(
    int DeckId,
    int EventId,
    string FormatCode,
    string EventName,
    string? EventDate,
    int Place,          // first number of the placement ("5-8" => 5), setto 999 when unknown
    string PlaceText,   // placement as printed on the site ("5-8")
    string DeckName,
    string Player)
{
    public string Url => Urls.Deck(EventId, DeckId, FormatCode);
}

//A single card line of a deck list
public sealed record DeckCard(string CardName, int Quantity, bool IsSideboard);

public sealed record DeckDetail(DeckSummary Summary, IReadOnlyList<DeckCard> Cards);

//A player ranked inside one format (category of events)
public sealed record PlayerRanking(
    string FormatCode,
    int Rank,
    string Player,
    int Score,
    IReadOnlyList<DeckDetail> Decks);

public sealed class ScrapeResult
{
    public List<DeckDetail> Decks { get; } = new();
    public List<PlayerRanking> TopPlayers { get; } = new();
}

public static class Urls
{
    public const string Base = "https://mtgtop8.com/";

    public static string Format(string code) => $"{Base}format?f={code}";
    public static string Event(int eventId, string code) => $"{Base}event?e={eventId}&f={code}";
    public static string Deck(int eventId, int deckId, string code) => $"{Base}event?e={eventId}&d={deckId}&f={code}";

    //Plain-text deck export (.dec). Much more stable to parse than the HTML deck page (I hope)
    public static string DeckExport(int deckId) => $"{Base}dec?d={deckId}&f=Deck";

    public static string Absolute(string href) => new Uri(new Uri(Base), href).ToString();
}
