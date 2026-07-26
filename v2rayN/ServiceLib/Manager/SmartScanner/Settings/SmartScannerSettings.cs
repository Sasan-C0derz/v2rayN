namespace ServiceLib.Manager.SmartScanner.Settings;

public class SmartScannerSettings
{
    /// <summary>
    /// فعال بودن Smart Scanner
    /// </summary>
    public bool Enabled { get; set; } = false;

    /// <summary>
    /// شروع خودکار هنگام اجرای برنامه
    /// </summary>
    public bool AutoStart { get; set; } = false;

    /// <summary>
    /// فاصله زمانی اسکن (دقیقه)
    /// </summary>
    public int ScanIntervalMinutes { get; set; } = 5;

    /// <summary>
    /// حداکثر تعداد تست همزمان
    /// </summary>
    public int MaxParallelWorkers { get; set; } = 8;

    /// <summary>
    /// Timeout هر تست (میلی‌ثانیه)
    /// </summary>
    public int TimeoutMilliseconds { get; set; } = 3000;

    /// <summary>
    /// حذف خودکار سرورهای مرده
    /// </summary>
    public bool RemoveDeadServers { get; set; } = true;
}
