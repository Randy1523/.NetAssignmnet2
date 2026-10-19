namespace UsageData;

//The "Data | Card usage | Pairings" strip shown at the top of every screen for navigation.
public static class NavBar
{
    public static ToolStrip Create(Form current)
    {
        var strip = new ToolStrip
        {
            Dock = DockStyle.Top,
            GripStyle = ToolStripGripStyle.Hidden,
            Padding = new Padding(8, 4, 8, 4),
            Font = new Font("Segoe UI", 10.5f),
        };

        Add(strip, current, "Data", () => Navigator.Data, current is DataPage);
        Add(strip, current, "Card usage", () => Navigator.CardUsage, current is CardUsagePage);
        Add(strip, current, "Pairings", () => Navigator.Pairings, current is PairingsPage);
        return strip;
    }

    private static void Add(ToolStrip strip, Form current, string text, Func<Form> target, bool isCurrent)
    {
        var button = new ToolStripButton(text)
        {
            DisplayStyle = ToolStripItemDisplayStyle.Text,
            Checked = isCurrent,
            Padding = new Padding(12, 4, 12, 4),
        };
        if (isCurrent) button.Font = new Font(strip.Font, FontStyle.Bold);
        button.Click += (_, _) => Navigator.GoTo(current, target());
        strip.Items.Add(button);
    }
}
