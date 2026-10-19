namespace UsageData;

public sealed class CardUsagePage : Form
{
    private readonly AppState _state;
    private readonly FilterBar _filter = new();
    private readonly DataGridView _grid = GridHelper.Create();
    private readonly DataGridView _archetypes = GridHelper.Create();
    private readonly DataGridView _copies = GridHelper.Create();
    private readonly GroupBox _archBox;
    private readonly GroupBox _copiesBox;
    private readonly Label _status = new() { AutoSize = true, Dock = DockStyle.Top, Padding = new Padding(10, 2, 10, 6) };
    private bool _dirty = true;

    public CardUsagePage(AppState state)
    {
        _state = state;
        Text = "Card usage - MTG Top8 Explorer";
        Font = new Font("Segoe UI", 9.5f);
        Size = new Size(1280, 800);
        MinimumSize = new Size(960, 600);
        StartPosition = FormStartPosition.CenterScreen;

        _archBox = GridHelper.Boxed("Archetypes playing the selected card", _archetypes);
        _copiesBox = GridHelper.Boxed("Copies played", _copies);

        var detail = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 1 };
        detail.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 62));
        detail.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38));
        detail.Controls.Add(_archBox, 0, 0);
        detail.Controls.Add(_copiesBox, 1, 0);

        var layout = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 2 };
        layout.RowStyles.Add(new RowStyle(SizeType.Percent, 58));
        layout.RowStyles.Add(new RowStyle(SizeType.Percent, 42));
        layout.Controls.Add(GridHelper.Boxed("Card usage", _grid), 0, 0);
        layout.Controls.Add(detail, 0, 1);

        // Dock order: Fill first, then the Top controls with the outermost one last.
        Controls.Add(layout);
        Controls.Add(_status);
        Controls.Add(_filter);
        Controls.Add(GridHelper.Heading("Card usage",
            "How many decks play each card. Select a card to see which archetypes play it and how many copies."));
        Controls.Add(NavBar.Create(this));

        _filter.Changed += (_, _) => Render();
        _grid.SelectionChanged += (_, _) => ShowDetails();

        _state.DataChanged += (_, _) => { if (Visible) ReloadData(); else _dirty = true; };
        VisibleChanged += (_, _) => { if (Visible && _dirty) ReloadData(); };
        FormClosed += (_, _) => Navigator.PageClosed(this);
    }

    private void ReloadData()
    {
        _dirty = false;
        _filter.SetFormats(_state.Decks.Select(d => d.Summary.FormatCode));
        Render();
    }

    private void Render()
    {
        if (_state.Decks.Count == 0)
        {
            _status.Text = "No data yet - open the Data screen.";
            GridHelper.Clear(_grid); GridHelper.Clear(_archetypes); GridHelper.Clear(_copies);
            return;
        }

        var f = _filter.Current;
        var rows = Analytics.CardUsage(_state.Decks, f);
        GridHelper.Show(_grid, rows,
            ("Card", "Card", null), ("Decks", "Decks", "N0"), ("DeckShare", "% of decks", "P1"),
            ("TotalCopies", "Total copies", "N0"), ("AvgCopies", "Avg copies when played", "0.00"));
        _status.Text = $"{rows.Count:N0} cards   •   {Analytics.ByFormat(_state.Decks, f.Format).Count:N0} decks in scope";
        ShowDetails();
    }

    private void ShowDetails()
    {
        if (_grid.CurrentRow?.DataBoundItem is not CardStat card)
        {
            GridHelper.Clear(_archetypes); GridHelper.Clear(_copies);
            return;
        }

        var (archetypes, copies) = Analytics.CardDetails(_state.Decks, _filter.Current, card.Card);
        _archBox.Text = $"Archetypes playing {card.Card}";
        _copiesBox.Text = $"Copies of {card.Card} played";

        GridHelper.Show(_archetypes, archetypes,
            ("Format", "Format", null), ("Archetype", "Archetype", null), ("DecksWithCard", "Decks with card", "N0"),
            ("ArchetypeDecks", "Archetype decks", "N0"), ("Share", "% of archetype", "P1"));
        GridHelper.Show(_copies, copies,
            ("Copies", "Copies", null), ("Decks", "Decks", "N0"), ("Share", "% of decks playing it", "P1"));
    }
}
