namespace ServiceLib.Manager.SmartScanner.Models;

public class ServerItem
{
    /// <summary>
    /// کانفیگ خام
    /// </summary>
    public string RawConfig { get; set; } = string.Empty;

    /// <summary>
    /// نوع پروتکل
    /// vmess / vless / trojan / ss / hy2
    /// </summary>
    public string Protocol { get; set; } = string.Empty;

    /// <summary>
    /// نام نمایشی
    /// </summary>
    public string Remark { get; set; } = string.Empty;

    /// <summary>
    /// از کدام Subscription آمده است
    /// </summary>
    public string SourceUrl { get; set; } = string.Empty;

    /// <summary>
    /// سالم است؟
    /// </summary>
    public bool IsAlive { get; set; }

    /// <summary>
    /// Delay
    /// </summary>
    public int Delay { get; set; }

    /// <summary>
    /// آخرین زمان تست
    /// </summary>
    public DateTime? LastCheckTime { get; set; }
}
