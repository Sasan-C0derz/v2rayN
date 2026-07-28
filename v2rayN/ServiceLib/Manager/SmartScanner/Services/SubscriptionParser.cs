using ServiceLib.Manager.SmartScanner.Models;

namespace ServiceLib.Manager.SmartScanner.Services;

public class SubscriptionParser
{
    public List<ServerItem> Parse(string content, string sourceUrl)
    {
        var result = new List<ServerItem>();

        if (string.IsNullOrWhiteSpace(content))
            return result;

        var lines = content.Split(
            new[] { "\r\n", "\n" },
            StringSplitOptions.RemoveEmptyEntries);

        foreach (var line in lines)
        {
            var text = line.Trim();

            if (string.IsNullOrWhiteSpace(text))
                continue;

            var protocolIndex = text.IndexOf("://");

            if (protocolIndex <= 0)
                continue;

            var protocol = text[..protocolIndex];

            var remark = ExtractRemark(text);

            result.Add(new ServerItem
            {
                RawConfig = text,
                Protocol = protocol,
                SourceUrl = sourceUrl,
                Remark = string.IsNullOrWhiteSpace(remark)
                            ? protocol
                            : remark
            });
        }

        return result;
    }

    private static string ExtractRemark(string config)
    {
        var index = config.LastIndexOf('#');

        if (index < 0)
            return string.Empty;

        var remark = config[(index + 1)..];

        return Uri.UnescapeDataString(remark);
    }
}
