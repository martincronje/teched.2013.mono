using QuickWeather.Core.Model;

namespace QuickWeather.Core.Services
{
    internal interface IGeoLocationService
    {
        void GetPositionAsync(ServiceCallback<GeoLocation> callback);
    }
}