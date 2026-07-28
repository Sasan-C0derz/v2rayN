using ServiceLib.Manager.SmartScanner.Models;
using ServiceLib.Manager.SmartScanner.Services;

namespace ServiceLib.Manager.SmartScanner;

public class SmartScannerEngine
{
    //==========================
    // State
    //==========================

    public SmartScannerState State { get; private set; } = SmartScannerState.Disabled;

    public event Action<SmartScannerState>? StateChanged;

    //==========================
    // Components
    //==========================

    private readonly SubscriptionDownloader _downloader = new();
    private readonly SubscriptionParser _parser = new();
    private readonly ServerRepository _repository = new();
    private readonly AliveChecker _aliveChecker = new();

    public SmartScannerEvents Events { get; } = new();

    public IReadOnlyList<ServerItem> Servers => _repository.Servers;

    //==========================
    // State Management
    //==========================

    private void SetState(SmartScannerState newState)
    {
        if (State == newState)
            return;

        State = newState;
        StateChanged?.Invoke(State);
    }

    public void Start()
    {
        SetState(SmartScannerState.Starting);
    }

    public void Stop()
    {
        SetState(SmartScannerState.Stopping);
    }

    public void Pause()
    {
        SetState(SmartScannerState.Paused);
    }

    public void Resume()
    {
        SetState(SmartScannerState.Running);
    }

    //==========================
    // Scan
    //==========================

    public async Task ScanSourceAsync(string url)
    {
        Events.RaiseStatus("Downloading...");

        var content = await _downloader.DownloadAsync(url);

        if (string.IsNullOrWhiteSpace(content))
        {
            Events.RaiseStatus("Download Failed");
            return;
        }

        Events.RaiseStatus("Parsing...");

        var servers = _parser.Parse(content, url);

        // Repository
        _repository.Clear();
        _repository.AddRange(servers);

        // Statistics
        Events.RaiseServerCount(_repository.Servers.Count);

        // Alive Check (فعلاً Mock)
        Events.RaiseStatus("Checking Alive...");

        var aliveServers = await _aliveChecker.CheckAliveAsync(
            _repository.Servers.ToList());

        Events.RaiseAliveCount(aliveServers.Count);

        // اطلاع به UI
        Events.RaiseServersUpdated(_repository.Servers);

        Events.RaiseStatus("Ready");
    }

    //==========================
    // Repository
    //==========================

    public IReadOnlyList<ServerItem> GetServers()
    {
        return _repository.Servers;
    }

    public int GetServerCount()
    {
        return _repository.Servers.Count;
    }

    public void Clear()
    {
        _repository.Clear();
    }
}
