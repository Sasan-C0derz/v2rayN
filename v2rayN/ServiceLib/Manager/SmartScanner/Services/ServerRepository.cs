using ServiceLib.Manager.SmartScanner.Models;

namespace ServiceLib.Manager.SmartScanner.Services;

public class ServerRepository
{
    private readonly List<ServerItem> _servers = new();

    public IReadOnlyList<ServerItem> Servers => _servers;

    public void AddRange(IEnumerable<ServerItem> servers)
    {
        _servers.AddRange(servers);
    }

    public void Clear()
    {
        _servers.Clear();
    }
}
