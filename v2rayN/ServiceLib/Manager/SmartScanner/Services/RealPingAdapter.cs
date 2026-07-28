using ServiceLib.Manager.SmartScanner.Models;

namespace ServiceLib.Manager.SmartScanner.Services;

public class RealPingAdapter
{
    public async Task<int> GetDelayAsync(ServerItem server)
    {
        // فعلاً تستی
        await Task.Delay(1);

        return -1;
    }
}   
