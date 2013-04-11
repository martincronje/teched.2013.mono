using QuickWeather.Core.Services;

namespace QuickWeather.Core.ViewController
{
    public partial class CurrentLocationWeatherViewController
    {
        public CurrentLocationWeatherViewController(ICurrentLocationWeatherView view, IWeatherService weatherService)
        {
            _weatherService = weatherService;
            _view = view;
            _geoLocationService = new GeoLocationService();
        }
    }
}
