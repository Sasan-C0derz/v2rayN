namespace ServiceLib.Manager.SmartScanner;

public class SmartScannerEngine
{
    public SmartScannerState State { get; private set; } = SmartScannerState.Disabled;

    public event Action<SmartScannerState>? StateChanged;

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
}
