namespace ServiceLib.Manager.SmartScanner;

public sealed class SmartScannerManager
{
    public static SmartScannerManager Instance { get; } = new();

    public SmartScannerEngine Engine { get; } = new();

    private SmartScannerManager()
    {
    }
}
