namespace ServiceLib.Manager.SmartScanner.Models;

public class SubscriptionSource
{
    /// <summary>
    /// آدرس Subscription
    /// </summary>
    public string Url { get; set; } = string.Empty;

    /// <summary>
    /// آیا این لینک فعال است؟
    /// </summary>
    public bool Enabled { get; set; } = true;

    /// <summary>
    /// تعداد کل سرورها
    /// </summary>
    public int TotalServers { get; set; }

    /// <summary>
    /// تعداد سرورهای سالم
    /// </summary>
    public int AliveServers { get; set; }

    /// <summary>
    /// آخرین زمان اسکن
    /// </summary>
    public DateTime? LastScanTime { get; set; }

    /// <summary>
    /// در حال اسکن است؟
    /// </summary>
    public bool IsScanning { get; set; }
}
