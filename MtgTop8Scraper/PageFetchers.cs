using PuppeteerSharp;

namespace MtgTop8;

/// Abstraction over "get me this page" so you can swap HttpClient for a real browser
public interface IPageFetcher : IAsyncDisposable
{
    //Returns the page's HTML.
    Task<string> GetHtmlAsync(string url, CancellationToken ct = default);

    //Returns the page body as plain text (used for the .dec deck export).
    Task<string> GetTextAsync(string url, CancellationToken ct = default);
}

//Spaces requests out so we never hammer the site
internal sealed class Throttle
{
    private readonly SemaphoreSlim _gate = new(1, 1);
    private readonly TimeSpan _delay;
    private DateTime _next = DateTime.MinValue;

    public Throttle(TimeSpan delay) => _delay = delay;

    public async Task WaitAsync(CancellationToken ct)
    {
        await _gate.WaitAsync(ct);
        try
        {
            var wait = _next - DateTime.UtcNow;
            if (wait > TimeSpan.Zero) await Task.Delay(wait, ct);
            _next = DateTime.UtcNow + _delay;
        }
        finally { _gate.Release(); }
    }
}

//Fast path: plain HttpClient. The site serves static HTML, so this is normally enough.
public sealed class HttpPageFetcher : IPageFetcher
{
    internal const string DefaultUserAgent =
        "Mozilla/5.0 (compatible; MtgTop8Scraper/1.0; personal research)";

    private readonly HttpClient _http;
    private readonly bool _ownsClient;
    private readonly Throttle _throttle;

    public HttpPageFetcher(TimeSpan? delayBetweenRequests = null, string? userAgent = null, HttpClient? client = null)
    {
        _ownsClient = client is null;
        _http = client ?? new HttpClient { Timeout = TimeSpan.FromSeconds(60) };
        _http.DefaultRequestHeaders.UserAgent.ParseAdd(userAgent ?? DefaultUserAgent);
        _throttle = new Throttle(delayBetweenRequests ?? TimeSpan.FromMilliseconds(1000));
    }

    public Task<string> GetHtmlAsync(string url, CancellationToken ct = default) => GetAsync(url, ct);
    public Task<string> GetTextAsync(string url, CancellationToken ct = default) => GetAsync(url, ct);

    private async Task<string> GetAsync(string url, CancellationToken ct)
    {
        const int maxAttempts = 4;
        for (var attempt = 1; ; attempt++)
        {
            await _throttle.WaitAsync(ct);
            using var resp = await _http.GetAsync(url, ct);

            if (resp.IsSuccessStatusCode)
                return await resp.Content.ReadAsStringAsync(ct); // honours the site's ISO-8859-1 charset

            var transient = (int)resp.StatusCode == 429 || (int)resp.StatusCode >= 500;
            if (!transient || attempt == maxAttempts)
                resp.EnsureSuccessStatusCode();

            await Task.Delay(TimeSpan.FromSeconds(Math.Pow(2, attempt)), ct); // back off
        }
    }

    public ValueTask DisposeAsync()
    {
        if (_ownsClient) _http.Dispose();
        return ValueTask.CompletedTask;
    }
}


//Chromium path using PuppeteerSharp. Use it if the site requires JavaScript (It won't, this is in case it breaks somehow.)

public sealed class PuppeteerPageFetcher : IPageFetcher
{
    private readonly Throttle _throttle;
    private readonly SemaphoreSlim _init = new(1, 1);
    private IBrowser? _browser;

    public PuppeteerPageFetcher(TimeSpan? delayBetweenRequests = null)
        => _throttle = new Throttle(delayBetweenRequests ?? TimeSpan.FromMilliseconds(1500));

    public Task<string> GetHtmlAsync(string url, CancellationToken ct = default)
        => WithPageAsync(url, p => p.GetContentAsync(), ct);

    public Task<string> GetTextAsync(string url, CancellationToken ct = default)
        => WithPageAsync(url, p => p.EvaluateExpressionAsync<string>("document.body.innerText"), ct);

    private async Task<IBrowser> GetBrowserAsync()
    {
        if (_browser is not null) return _browser;
        await _init.WaitAsync();
        try
        {
            if (_browser is null)
            {
                await new BrowserFetcher().DownloadAsync(); // Chromium download stuff (once)
                _browser = await Puppeteer.LaunchAsync(new LaunchOptions
                {
                    Headless = true,
                    Args = new[] { "--no-sandbox" }
                });
            }
            return _browser;
        }
        finally { _init.Release(); }
    }

    private async Task<string> WithPageAsync(string url, Func<IPage, Task<string>> read, CancellationToken ct)
    {
        await _throttle.WaitAsync(ct);
        var browser = await GetBrowserAsync();
        var page = await browser.NewPageAsync();
        try
        {
            await page.SetUserAgentAsync(HttpPageFetcher.DefaultUserAgent);
            var resp = await page.GoToAsync(url, WaitUntilNavigation.DOMContentLoaded);
            if (resp is { Ok: false })
                throw new HttpRequestException($"GET {url} returned {(int)resp.Status}");
            return await read(page);
        }
        finally { await page.CloseAsync(); }
    }

    public async ValueTask DisposeAsync()
    {
        if (_browser is not null) await _browser.CloseAsync();
    }
}
