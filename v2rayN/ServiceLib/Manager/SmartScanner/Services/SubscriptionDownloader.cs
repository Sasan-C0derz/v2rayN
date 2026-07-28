namespace ServiceLib.Manager.SmartScanner.Services;

public class SubscriptionDownloader
{
    private readonly HttpClient _httpClient = new();

    public async Task<string?> DownloadAsync(string url, CancellationToken cancellationToken = default)
    {
        try
        {
            url = NormalizeUrl(url);

            return await _httpClient.GetStringAsync(url, cancellationToken);
        }
        catch
        {
            return null;
        }
    }

    private static string NormalizeUrl(string url)
    {
        if (url.Contains("github.com") && url.Contains("/blob/"))
        {
            return url
                .Replace("github.com", "raw.githubusercontent.com")
                .Replace("/blob/", "/");
        }

        return url;
    }
}
