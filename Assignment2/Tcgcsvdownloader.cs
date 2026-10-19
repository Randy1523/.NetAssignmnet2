using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Assignment2
{
    public static class TcgCsvDownloader
    {
        private const string BaseUrl = "https://tcgcsv.com/tcgplayer";
        
        // setting directory, quick and dirty so it goes in the right data folder.
        private static readonly string DataRoot = Path.Combine(FindProjectFolder(), "data");

        private static string FindProjectFolder()
        {
            var dir = new DirectoryInfo(AppContext.BaseDirectory);
            while (dir != null)
            {
                if (dir.GetFiles("*.csproj").Length > 0)
                    return dir.FullName;
                dir = dir.Parent;
            }
            return AppContext.BaseDirectory;
        }
        // Folder -> (categoryId, groupIds). Duplicates are removed automatically.
        private static readonly Dictionary<string, (int Category, int[] Groups)> Jobs = new()
        {
            [Path.Combine(DataRoot, "Magic")] = (1, new[] { 1, 2, 3, 4, 2, 1477, 2893 }),
            [Path.Combine(DataRoot, "Pokemon")] = (3, new[] { 604, 24584, 24448, 1842, 1842, 1780 }),
        };

        private static readonly HttpClient Http = CreateClient();

        private static HttpClient CreateClient()
        {
            var client = new HttpClient { Timeout = TimeSpan.FromMinutes(2) };
            client.DefaultRequestHeaders.UserAgent.ParseAdd("TcgCsvDownloader/1.0");
            return client;
        }

        //Console window for a WinForms app, decided this was the best for showing progress, progress bars aren't too good for complex tasks.
        [DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        private static void EnsureConsole()
        {
            if (GetConsoleWindow() == IntPtr.Zero)
                AllocConsole();
        }

        //Downloader, outputs to console
        public static async Task RunAsync()
        {
            EnsureConsole();

            foreach (var (folder, (category, groups)) in Jobs)
            {
                Console.WriteLine($"== {folder} ==");
                Directory.CreateDirectory(folder);

                // Download everything first, so old copies are only removed if all downloads succeed.
                var downloaded = new Dictionary<string, byte[]>();
                foreach (var group in groups.Distinct())
                {
                    var url = $"{BaseUrl}/{category}/{group}/ProductsAndPrices.csv";
                    try
                    {
                        using var response = await Http.GetAsync(url);
                        response.EnsureSuccessStatusCode();

                        // Use the filename the server suggests, e.g. 10thEditionProductsAndPrices.csv
                        var cd = response.Content.Headers.ContentDisposition;
                        var name = (cd?.FileNameStar ?? cd?.FileName)?.Trim('"');
                        name = string.IsNullOrWhiteSpace(name)
                            ? $"{group}_ProductsAndPrices.csv"   // fallback if the server sends no name
                            : Path.GetFileName(name);
                        foreach (var c in Path.GetInvalidFileNameChars())
                            name = name.Replace(c, '_');

                        downloaded[name] = await response.Content.ReadAsByteArrayAsync();
                        Console.WriteLine($"Downloaded {url} -> {name}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"FAILED     {url}: {ex.Message}");
                    }
                }

                if (downloaded.Count != groups.Distinct().Count())
                {
                    Console.WriteLine("Some downloads failed, existing files kept for failed updates.\n");
                    continue;
                }

                // Remove older copies, then write the new ones.
                foreach (var old in Directory.GetFiles(folder, "*.csv"))
                    File.Delete(old);

                foreach (var (name, bytes) in downloaded)
                    await File.WriteAllBytesAsync(Path.Combine(folder, name), bytes);

                Console.WriteLine($"Saved {downloaded.Count} files.\n");
            }

            Console.WriteLine("Done. Close this console to close the appliaction and update the database.");
        }
    }
}
