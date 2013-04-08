using Android.App;
using Android.Content;
using QuickWeather.Core.Services;

namespace QuickWeather.Core.ViewController
{
    public partial class CurrentLocationWeatherViewController
    {
        private readonly Activity _activity;

        public CurrentLocationWeatherViewController(ICurrentLocationWeatherView view, IWeatherService weatherService, Activity activity)
        {
            _view = view;
            _weatherService = weatherService;
            _activity = activity;
            _geoLocationService = new GeoLocationService(_activity);
        }
    }
}