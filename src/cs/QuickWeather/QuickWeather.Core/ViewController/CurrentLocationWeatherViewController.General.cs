using System.Threading.Tasks;
using QuickWeather.Core.Proxy;
using Xamarin.Geolocation;

namespace QuickWeather.Core.ViewController
{
    public partial class CurrentLocationWeatherViewController
    {
        public CurrentLocationWeatherViewController(ICurrentLocationWeatherView view, IWeatherService service)
        {
            _service = service;
            _view = view;
            _scheduler = TaskScheduler.FromCurrentSynchronizationContext();
            _geolocator = new Geolocator { DesiredAccuracy = 50 };
        }
    }
}
