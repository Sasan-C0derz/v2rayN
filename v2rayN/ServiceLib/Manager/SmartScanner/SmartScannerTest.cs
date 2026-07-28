namespace ServiceLib.Manager.SmartScanner;

public static class SmartScannerTest
{
    public static async Task Test()
    {
        var engine = new SmartScannerEngine();

        await engine.ScanSourceAsync(
            "https://raw.githubusercontent.com/barry-far/V2ray-Config/main/Sub1.txt");

        Console.WriteLine($"Servers : {engine.GetServerCount()}");
    }
}
