using MtgTop8;

namespace UsageData;

public sealed class DataPage : Form
{
    private readonly AppState _state;
    private readonly CheckedListBox _formats = new() { CheckOnClick = true, Dock = DockStyle.Fill };
    private readonly NumericUpDown _events = new() { Minimum = 1, Maximum = 500, Value = 5, Width = 70 };
    private readonly NumericUpDown _maxDecks = new() { Minimum = 0, Maximum = 1000, Value = 0, Width = 70 };
    private readonly ComboBox _fetcher = new() { DropDownStyle = ComboBoxStyle.DropDownList, Width = 250 };
    private readonly Button _scrape = new() { Text = "Scrape selected formats", AutoSize = true };
    private readonly Button _cancel = new() { Text = "Cancel", AutoSize = true, Enabled = false };
    private readonly ProgressBar _bar = new() { Width = 300, Height = 12, MarqueeAnimationSpeed = 30 };
    private readonly Label _status = new() { AutoSize = true, Dock = DockStyle.Top, Padding = new Padding(10, 6, 10, 6), Font = new Font("Segoe UI", 10f, FontStyle.Bold) };
    private readonly TextBox _log = new() { Multiline = true, ReadOnly = true, ScrollBars = ScrollBars.Vertical, Dock = DockStyle.Fill, BackColor = SystemColors.Window, Font = new Font("Consolas", 9f) };
    private CancellationTokenSource? _cts;

    public DataPage(AppState state)
    {
        _state = state;
        Text = "Data - MTG Top8 Explorer";
        Font = new Font("Segoe UI", 9.5f);
        Size = new Size(1100, 760);
        MinimumSize = new Size(900, 600);
        StartPosition = FormStartPosition.CenterScreen;

        foreach (var kv in Formats.Names)
            _formats.Items.Add(new FormatItem(kv.Key, $"{kv.Value} ({kv.Key})"), kv.Key is "ST" or "PI" or "MO" or "LE");

        _fetcher.Items.AddRange(new object[] { "HttpClient (fast, default)", "PuppeteerSharp (headless Chromium)" });
        _fetcher.SelectedIndex = 0;

        var formatsBox = new GroupBox { Text = "Formats to scrape", Size = new Size(250, 190) };
        formatsBox.Controls.Add(_formats);

        var settings = new FlowLayoutPanel { FlowDirection = FlowDirection.TopDown, WrapContents = false, AutoSize = true };
        settings.Controls.Add(Row("Recent events per format", _events));
        settings.Controls.Add(Row("Max decks per event (0 = all)", _maxDecks));
        settings.Controls.Add(Row("Page fetcher", _fetcher));
        settings.Controls.Add(Row("", _scrape, _cancel));
        settings.Controls.Add(Row("", _bar));

        var dataButtons = new FlowLayoutPanel { FlowDirection = FlowDirection.LeftToRight, AutoSize = true, Margin = new Padding(0, 14, 0, 0) };
        var load = new Button { Text = "Load saved data", AutoSize = true };
        var import = new Button { Text = "Import CSV…", AutoSize = true };
        var export = new Button { Text = "Export CSV…", AutoSize = true };
        var clear = new Button { Text = "Clear data", AutoSize = true };
        dataButtons.Controls.AddRange(new Control[] { load, import, export, clear });
        settings.Controls.Add(dataButtons);

        var top = new FlowLayoutPanel { Dock = DockStyle.Top, AutoSize = true, Padding = new Padding(8) };
        top.Controls.Add(formatsBox);
        top.Controls.Add(settings);

        // Dock order: add the Fill control first, then the Top ones (the last one added ends up outermost).
        Controls.Add(_log);
        Controls.Add(top);
        Controls.Add(_status);
        Controls.Add(GridHelper.Heading("Data",
            "Scrape mtgtop8.com (about 1 request per second) or import a CSV. Data is cached in %AppData%\\MtgTop8Explorer."));
        Controls.Add(NavBar.Create(this));

        _scrape.Click += OnScrape;
        _cancel.Click += (_, _) => _cts?.Cancel();
        load.Click += (_, _) => Guard(() => Log($"Loaded {_state.Load():N0} decks from the cache."));
        import.Click += (_, _) => OnImport();
        export.Click += (_, _) => OnExport();
        clear.Click += (_, _) =>
        {
            if (MessageBox.Show("Remove all loaded decks from memory and the cache?", "Clear data",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            _state.Clear();
            Guard(_state.Save);
            Log("Data cleared.");
        };

        _state.DataChanged += (_, _) => UpdateStatus();
        FormClosing += (_, _) => _cts?.Cancel();
        FormClosed += (_, _) => Navigator.PageClosed(this);
        UpdateStatus();
    }

    private void UpdateStatus()
    {
        _status.Text = _state.Decks.Count == 0
            ? "No data loaded yet."
            : $"{_state.Decks.Count:N0} decks from {_state.Decks.Select(d => d.Summary.EventId).Distinct().Count():N0} events " +
              $"in {_state.Decks.Select(d => d.Summary.FormatCode).Distinct().Count()} formats are loaded.";
    }

    private async void OnScrape(object? sender, EventArgs e)
    {
        var codes = _formats.CheckedItems.Cast<FormatItem>().Select(i => i.Code!).ToList();
        if (codes.Count == 0) { MessageBox.Show("Tick at least one format."); return; }

        _cts = new CancellationTokenSource();
        SetBusy(true);
        IPageFetcher fetcher = _fetcher.SelectedIndex == 1 ? new PuppeteerPageFetcher() : new HttpPageFetcher();
        var progress = new Progress<string>(Log);

        try
        {
            await using var scraper = new MtgTop8Scraper(fetcher);
            foreach (var code in codes)
            {
                _cts.Token.ThrowIfCancellationRequested();
                // One format at a time so partial results survive a cancel or an error.
                var result = await scraper.ScrapeAsync(new ScrapeOptions
                {
                    FormatCodes = new[] { code },
                    MaxEventsPerFormat = (int)_events.Value,
                    MaxDecksPerEvent = _maxDecks.Value == 0 ? int.MaxValue : (int)_maxDecks.Value,
                }, progress, _cts.Token);

                var added = _state.Add(result.Decks);
                _state.Save();
                Log($"[{code}] finished: {added:N0} new decks ({_state.Decks.Count:N0} total).");
            }
            Log("All done.");
        }
        catch (OperationCanceledException) { Log("Cancelled (decks scraped so far were kept)."); }
        catch (Exception ex)
        {
            Log("ERROR: " + ex.Message);
            MessageBox.Show(ex.Message, "Scrape failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally { SetBusy(false); }
    }

    private void OnImport()
    {
        using var dlg = new OpenFileDialog { Filter = "CSV files (*.csv)|*.csv", Title = "Import all_deck_cards.csv" };
        if (dlg.ShowDialog() != DialogResult.OK) return;
        Guard(() =>
        {
            var added = _state.Add(CsvImport.Read(dlg.FileName));
            _state.Save();
            Log($"Imported {added:N0} new decks from {Path.GetFileName(dlg.FileName)}.");
        });
    }

    private void OnExport()
    {
        if (_state.Decks.Count == 0) { MessageBox.Show("Nothing to export yet."); return; }
        using var dlg = new FolderBrowserDialog { Description = "Choose a folder for the CSV files" };
        if (dlg.ShowDialog() != DialogResult.OK) return;
        Guard(() =>
        {
            var result = new ScrapeResult();
            result.Decks.AddRange(_state.Decks);
            result.TopPlayers.AddRange(Analytics.TopPlayers(_state.Decks, null, 10));
            CsvExporter.WriteAll(dlg.SelectedPath, result);
            Log("CSV files written to " + dlg.SelectedPath);
        });
    }

    private void SetBusy(bool busy)
    {
        _scrape.Enabled = !busy;
        _cancel.Enabled = busy;
        _bar.Style = busy ? ProgressBarStyle.Marquee : ProgressBarStyle.Continuous;
    }

    private void Guard(Action action)
    {
        try { action(); }
        catch (Exception ex) { Log("ERROR: " + ex.Message); MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
    }

    private void Log(string message) => _log.AppendText($"{DateTime.Now:HH:mm:ss}  {message}{Environment.NewLine}");

    private static FlowLayoutPanel Row(string label, params Control[] controls)
    {
        var row = new FlowLayoutPanel { AutoSize = true, WrapContents = false, Margin = new Padding(0, 2, 0, 2) };
        row.Controls.Add(new Label { Text = label, AutoSize = true, MinimumSize = new Size(190, 0), Margin = new Padding(0, 6, 0, 0) });
        row.Controls.AddRange(controls);
        return row;
    }
}
