using System.Threading.Tasks;
using QuickWeather.Core.Services;
using Xamarin.Geolocation;

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
