namespace UsageData;

//Friendly names for mtgtop8 format codes. Add more codes here if you scrape other formats.
public static class Formats
{
    public static readonly IReadOnlyDictionary<string, string> Names =
        new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            ["ST"] = "Standard",
            ["PI"] = "Pioneer",
            ["MO"] = "Modern",
            ["LE"] = "Legacy",
            ["VI"] = "Vintage",
            ["PAU"] = "Pauper",
            ["cEDH"] = "cEDH",
            ["EDH"] = "Duel Commander",
            ["PREM"] = "Premodern",
        };

    public static string Name(string code) => Names.TryGetValue(code, out var n) ? n : code;
}

//Combo/list item: Code == null means "all formats".
public sealed record FormatItem(string? Code, string Label)
{
    public override string ToString() => Label;
}
