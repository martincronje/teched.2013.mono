using System.Threading.Tasks;
using Android.Content;
using Xamarin.Geolocation;

namespace QuickWeather.Core.ViewController
{
    public partial class CurrentLocationWeatherViewController
    {
        public CurrentLocationWeatherViewController(ICurrentLocationWeatherView view, Context context)
        {
            _view = view;
            _scheduler = TaskScheduler.FromCurrentSynchronizationContext();
            _geolocator = new Geolocator(context) {DesiredAccuracy = 50};
        }
    }
}