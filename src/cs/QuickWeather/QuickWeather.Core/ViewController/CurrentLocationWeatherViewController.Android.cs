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
            _geolocator = new Geolocator(context) { DesiredAccuracy = 50 };
            _geolocator.PositionError += OnListeningError;
            _geolocator.PositionChanged += OnPositionChanged;
        }

        private static void OnPositionChanged(object sender, PositionEventArgs e)
        {
            
        }

        private static void OnListeningError(object sender, PositionErrorEventArgs e)
        {
            
        }
    }
}