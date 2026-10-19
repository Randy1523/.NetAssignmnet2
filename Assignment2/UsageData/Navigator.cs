namespace UsageData;

// Owns the shared data and the three screens (each its own Form). Moving between screens
// shows the target form at the same place/size and hides the current one. Decided to use this here to make sharing data easier.
// Integrated into Assignment2: the screens are opened from MainMenu via Navigator.Open().
public static class Navigator
{
    private static DataPage? _data;
    private static CardUsagePage? _cardUsage;
    private static PairingsPage? _pairings;
    private static bool _loaded;
    private static bool _closingAll;

    public static AppState State { get; } = new();

    public static DataPage Data => _data is { IsDisposed: false } ? _data : _data = new DataPage(State);
    public static CardUsagePage CardUsage => _cardUsage is { IsDisposed: false } ? _cardUsage : _cardUsage = new CardUsagePage(State);
    public static PairingsPage Pairings => _pairings is { IsDisposed: false } ? _pairings : _pairings = new PairingsPage(State);

    /// <summary>Entry point from MainMenu: shows the explorer (or brings it to front if already open).</summary>
    public static void Open()
    {
        if (!_loaded)
        {
            try { State.Load(); }
            catch (Exception ex) { MessageBox.Show("Could not read the saved data: " + ex.Message); }
            _loaded = true;
        }

        // Already open? Bring whichever page is visible to the front.
        foreach (var page in new Form?[] { _data, _cardUsage, _pairings })
        {
            if (page is { IsDisposed: false, Visible: true })
            {
                if (page.WindowState == FormWindowState.Minimized) page.WindowState = FormWindowState.Normal;
                page.Activate();
                return;
            }
        }

        // Start on Card usage if there is already data, otherwise on the Data screen.
        Form start = State.Decks.Count > 0 ? CardUsage : Data;
        start.Show();
        start.Activate();
    }

    public static void GoTo(Form from, Form to)
    {
        if (ReferenceEquals(from, to)) return;

        var bounds = from.WindowState == FormWindowState.Normal ? from.Bounds : from.RestoreBounds;
        to.StartPosition = FormStartPosition.Manual;
        to.Bounds = bounds;
        to.WindowState = from.WindowState == FormWindowState.Minimized ? FormWindowState.Normal : from.WindowState;

        to.Show();
        from.Hide();
    }

    /// <summary>Called when any explorer page is closed: closes the other (hidden) pages too,
    /// without exiting the application, so the explorer can be reopened from MainMenu.</summary>
    public static void PageClosed(Form closed)
    {
        if (_closingAll) return;
        _closingAll = true;
        try
        {
            foreach (var page in new Form?[] { _data, _cardUsage, _pairings })
                if (page != null && !ReferenceEquals(page, closed) && !page.IsDisposed)
                    page.Close();
        }
        finally { _closingAll = false; }
    }
}
