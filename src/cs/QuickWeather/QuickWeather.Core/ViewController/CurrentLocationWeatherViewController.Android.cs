using Android.Content;
using QuickWeather.Core.Services;

namespace QuickWeather.Core.ViewController
{
    public partial class CurrentLocationWeatherViewController
    {
        public CurrentLocationWeatherViewController(ICurrentLocationWeatherView view, IWeatherService weatherService, Context context)
        {
            _view = view;
            _weatherService = weatherService;
            _geoLocationService = new GeoLocationService(context);
        }
    }
}