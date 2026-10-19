namespace UsageData;

public sealed class PairingsPage : Form
{
    private readonly AppState _state;
    private readonly FilterBar _filter = new();
    private readonly NumericUpDown _min = new() { Minimum = 1, Maximum = 10000, Value = 3, Width = 70 };
    private readonly DataGridView _grid = GridHelper.Create();
    private readonly Label _status = new() { AutoSize = true, Dock = DockStyle.Top, Padding = new Padding(10, 2, 10, 6) };
    private bool _dirty = true;
    private int _version;

    public PairingsPage(AppState state)
    {
        _state = state;
        Text = "Pairings - MTG Top8 Explorer";
        Font = new Font("Segoe UI", 9.5f);
        Size = new Size(1280, 800);
        MinimumSize = new Size(960, 600);
        StartPosition = FormStartPosition.CenterScreen;

        var options = new FlowLayoutPanel { Dock = DockStyle.Top, AutoSize = true, Padding = new Padding(8, 0, 8, 0) };
        options.Controls.Add(new Label { Text = "Min. decks together", AutoSize = true, Margin = new Padding(10, 6, 2, 0) });
        options.Controls.Add(_min);

        // Dock order: Fill first, then the Top controls with the outermost one last.
        Controls.Add(GridHelper.Boxed("Cards played together", _grid));
        Controls.Add(_status);
        Controls.Add(options);
        Controls.Add(_filter);
        Controls.Add(GridHelper.Heading("Pairings",
            "Enter a card name to see what it is played with; leave it empty for the most common pairs overall.\n" +
            "'B in A's decks' = share of decks with A that also run B. Lift above 1.0 means the two appear together more often than chance."));
        Controls.Add(NavBar.Create(this));

        _filter.Changed += (_, _) => Render();
        _min.ValueChanged += (_, _) => Render();

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

    private async void Render()
    {
        var version = ++_version;   // ignore results of superseded searches
        if (_state.Decks.Count == 0)
        {
            _status.Text = "No data yet - open the Data screen.";
            GridHelper.Clear(_grid);
            return;
        }

        _status.Text = "Calculating...";
        var filter = _filter.Current;
        var min = (int)_min.Value;
        var decks = _state.Decks.ToList();

        try
        {
            var rows = await Task.Run(() => Analytics.Pairs(decks, filter, min));
            if (version != _version) return;

            GridHelper.Show(_grid, rows,
                ("CardA", "Card", null), ("CardB", "Played with", null), ("Together", "Decks together", "N0"),
                ("ShareOfDecks", "% of all decks", "P1"), ("BInADecks", "B in A's decks", "P1"),
                ("AInBDecks", "A in B's decks", "P1"), ("Lift", "Lift", "0.00"));
            _status.Text = $"{rows.Count:N0} pairs shown (top 1,000 by decks together)   •   " +
                           $"{Analytics.ByFormat(decks, filter.Format).Count:N0} decks in scope";
        }
        catch (Exception ex)
        {
            if (version == _version) _status.Text = "Error: " + ex.Message;
        }
    }
}
