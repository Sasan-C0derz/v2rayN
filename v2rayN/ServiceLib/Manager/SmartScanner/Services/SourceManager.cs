using ServiceLib.Manager.SmartScanner.Models;

namespace ServiceLib.Manager.SmartScanner.Services;

public class SourceManager
{
    private readonly List<SubscriptionSource> _sources = new();

    public IReadOnlyList<SubscriptionSource> Sources => _sources;

    public bool Add(SubscriptionSource source)
    {
        if (string.IsNullOrWhiteSpace(source.Url))
            return false;

        if (_sources.Any(x =>
            x.Url.Equals(source.Url, StringComparison.OrdinalIgnoreCase)))
            return false;

        _sources.Add(source);
        return true;
    }

    public bool Remove(string url)
    {
        var source = _sources.FirstOrDefault(x =>
            x.Url.Equals(url, StringComparison.OrdinalIgnoreCase));

        if (source == null)
            return false;

        _sources.Remove(source);
        return true;
    }

    public bool Enable(string url)
    {
        var source = _sources.FirstOrDefault(x =>
            x.Url.Equals(url, StringComparison.OrdinalIgnoreCase));

        if (source == null)
            return false;

        source.Enabled = true;
        return true;
    }

    public bool Disable(string url)
    {
        var source = _sources.FirstOrDefault(x =>
            x.Url.Equals(url, StringComparison.OrdinalIgnoreCase));

        if (source == null)
            return false;

        source.Enabled = false;
        return true;
    }

    public void Clear()
    {
        _sources.Clear();
    }
}
