using ServiceLib.Manager.SmartScanner.Models;

namespace ServiceLib.Manager.SmartScanner;

public class SmartScannerEvents
{
    public event Action<int>? ServerCountChanged;

    public event Action<int>? AliveCountChanged;

    public event Action<string>? StatusChanged;

    public event Action<IReadOnlyList<ServerItem>>? ServersUpdated;

    internal void RaiseServersUpdated(IReadOnlyList<ServerItem> servers)
    {
        ServersUpdated?.Invoke(servers);
    }

    internal void RaiseServerCount(int count)
    {
        ServerCountChanged?.Invoke(count);
    }

    internal void RaiseAliveCount(int count)
    {
        AliveCountChanged?.Invoke(count);
    }

    internal void RaiseStatus(string status)
    {
        StatusChanged?.Invoke(status);
    }
}
