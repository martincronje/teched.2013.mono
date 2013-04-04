using System.Threading.Tasks;
using Xamarin.Geolocation;

namespace QuickWeather.Core.ViewController
{
    public partial class CurrentLocationWeatherViewController
    {
        public CurrentLocationWeatherViewController(ICurrentLocationWeatherView view)
        {
            _view = view;
            _scheduler = TaskScheduler.FromCurrentSynchronizationContext();
            _geolocator = new Geolocator { DesiredAccuracy = 50 };
        }
    }
}
