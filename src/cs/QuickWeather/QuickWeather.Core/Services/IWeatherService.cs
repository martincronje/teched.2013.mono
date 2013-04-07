using QuickWeather.Core.Model;

namespace QuickWeather.Core.Services
{
    public interface IWeatherService
    {
        void LookupStationsAsync(double latitude, double longitude, ServiceCallback<OfficialStations> callback);
        void LookupForecastAsync(double latitude, double longitude, ServiceCallback<ForecastDays> callback);
        ForecastDays LookupForecast(double latitude, double longitude);
        OfficialStations LookupStations(double latitude, double longitude);
    }
}