namespace UsageData;

//Shared search bar: card name, event format, board and basic-land toggle.
public sealed class FilterBar : FlowLayoutPanel
{
    private readonly TextBox _card = new() { Width = 240, PlaceholderText = "Card name (partial is fine)" };
    private readonly ComboBox _format = new() { DropDownStyle = ComboBoxStyle.DropDownList, Width = 160 };
    private readonly ComboBox _board = new() { DropDownStyle = ComboBoxStyle.DropDownList, Width = 120 };
    private readonly CheckBox _basics = new() { Text = "Hide basic lands", AutoSize = true, Checked = true, Margin = new Padding(14, 5, 0, 0) };
    private readonly System.Windows.Forms.Timer _debounce = new() { Interval = 300 };
    private readonly bool _showBasics;
    private bool _updating;

    public event EventHandler? Changed;

    public FilterBar(bool showCard = true, bool showBoard = true, bool showBasics = true)
    {
        _showBasics = showBasics;
        Dock = DockStyle.Top;
        AutoSize = true;
        AutoSizeMode = AutoSizeMode.GrowAndShrink;
        Padding = new Padding(8, 8, 8, 4);

        if (showCard) { Controls.Add(Caption("Card name")); Controls.Add(_card); }
        Controls.Add(Caption("Event format")); Controls.Add(_format);
        if (showBoard) { Controls.Add(Caption("Board")); Controls.Add(_board); }
        if (showBasics) Controls.Add(_basics);

        _format.Items.Add(new FormatItem(null, "All formats"));
        _format.SelectedIndex = 0;
        _board.Items.AddRange(new object[] { "Main deck", "Sideboard", "Main + side" });
        _board.SelectedIndex = 0;

        _card.TextChanged += (_, _) => { _debounce.Stop(); _debounce.Start(); };
        _debounce.Tick += (_, _) => { _debounce.Stop(); Raise(); };
        _format.SelectedIndexChanged += (_, _) => Raise();
        _board.SelectedIndexChanged += (_, _) => Raise();
        _basics.CheckedChanged += (_, _) => Raise();
    }

    public string? Card => string.IsNullOrWhiteSpace(_card.Text) ? null : _card.Text.Trim();
    public string? FormatCode => (_format.SelectedItem as FormatItem)?.Code;
    public BoardScope Board => (BoardScope)Math.Max(0, _board.SelectedIndex);
    public bool HideBasics => _showBasics && _basics.Checked;
    public Filter Current => new(Card, FormatCode, Board, HideBasics);

    //Refills the format dropdown with the formats present in the data.
    public void SetFormats(IEnumerable<string> codes)
    {
        _updating = true;
        var previous = FormatCode;
        _format.Items.Clear();
        _format.Items.Add(new FormatItem(null, "All formats"));
        foreach (var code in codes.Distinct().OrderBy(Formats.Name))
            _format.Items.Add(new FormatItem(code, Formats.Name(code)));

        var idx = _format.Items.Cast<FormatItem>().ToList().FindIndex(i => i.Code == previous);
        _format.SelectedIndex = Math.Max(0, idx);
        _updating = false;
    }

    private void Raise()
    {
        if (!_updating) Changed?.Invoke(this, EventArgs.Empty);
    }

    private static Label Caption(string text)
        => new() { Text = text, AutoSize = true, Margin = new Padding(10, 7, 2, 0) };

    protected override void Dispose(bool disposing)
    {
        if (disposing) _debounce.Dispose();
        base.Dispose(disposing);
    }
}
