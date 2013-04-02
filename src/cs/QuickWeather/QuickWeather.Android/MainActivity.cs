using System;
using System.Linq;
using Android.App;
using Android.Widget;
using Android.OS;
using QuickWeather.Core.Model;
using QuickWeather.Core.ViewController;

namespace QuickWeather.Android
{
    [Activity(Label = "QuickWeather.Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, ICurrentLocationWeatherView
    {
        private CurrentLocationWeatherViewController _viewController;
        private TextView _coordTextBox;
        private TextView _stationTextBox;
        private TextView _weatherTextBox;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            var button = FindViewById<Button>(Resource.Id.button);
            button.Click += (sender, args) => _viewController.FetchPosition();

            _viewController = new CurrentLocationWeatherViewController(this, this);
            _coordTextBox = FindViewById<TextView>(Resource.Id.coordTextView);
            _stationTextBox = FindViewById<TextView>(Resource.Id.stationTextView);
            _weatherTextBox = FindViewById<TextView>(Resource.Id.weatherTextView);
        }

        public void DisplayCurrentLocation(GeoLocation geoLocation)
        {
            _coordTextBox.Text = string.Format("Coordinates {0}", geoLocation.ToFriendlyString());
            _viewController.FetchLocations(geoLocation);
        }

        public void DisplayClosestWeatherStations(OfficialStations stations)
        {
            var station = stations.First();

            _stationTextBox.Text = string.Format("Station: {0}, {1}", station.City, station.Country);
            _viewController.FetchWeather(station.Location);
        }

        public void DisplayForecast(ForecastDays forecast)
        {
            var forecastDay = forecast.First();
            _weatherTextBox.Text = string.Format("Today High: {0}", forecastDay.High);
        }

        public void DisplayError(Exception exception)
        {
            _coordTextBox.Text = string.Format("Error: {0}", exception.Message);
        }
    }
}

