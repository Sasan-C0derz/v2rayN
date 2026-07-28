using ServiceLib.Manager.SmartScanner.Models;

namespace ServiceLib.Manager.SmartScanner.Services;

public class AliveChecker
{
    private readonly RealPingAdapter _realPing = new();

    public async Task<List<ServerItem>> CheckAliveAsync(List<ServerItem> servers)
    {
        var result = new List<ServerItem>();

        foreach (var server in servers)
        {
            if (await IsAlive(server))
            {
                result.Add(server);
            }
        }

        return result;
    }

    private async Task<bool> IsAlive(ServerItem server)
    {
        var delay = await _realPing.GetDelayAsync(server);

        return delay > 0;
    }
}
