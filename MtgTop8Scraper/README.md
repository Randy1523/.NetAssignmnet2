# MtgTop8Scraper

.NET 8 class library: scrapes public deck data from mtgtop8.com using AngleSharp (parsing) and
HttpClient or PuppeteerSharp (fetching), and writes CSV.

```csharp
using MtgTop8;

var progress = new Progress<string>(Console.WriteLine);

// Default: HttpClient. For a real headless browser use: new MtgTop8Scraper(new PuppeteerPageFetcher())
await using var scraper = new MtgTop8Scraper();

var result = await scraper.ScrapeAsync(new ScrapeOptions
{
    FormatCodes = new[] { "ST", "MO", "LE" },
    MaxEventsPerFormat = 5,
    TopPlayersPerFormat = 10
}, progress);

CsvExporter.WriteAll("output", result);
// output/all_deck_cards.csv             every card in every deck, grouped by deck
// output/top_players_decks_cards.csv    top 10 players per format, their decks and cards
```

Output columns: Format, EventId, EventName, EventDate, Place, DeckId, DeckName, Player, Board, Card, Quantity, DeckUrl
(top-players file adds PlayerRank, PlayerScore up front).

PS this took way too long to learn and make don't break please