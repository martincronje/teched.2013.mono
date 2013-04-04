using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using QuickWeather.Core.Model;
using QuickWeather.Core.Proxy.Forecast;
using QuickWeather.Core.Proxy.Location;
using QuickWeather.Core.ViewController;

namespace QuickWeather.WindowsPhone
{
    public partial class MainPage : ICurrentLocationWeatherView
    {
        private readonly TextBlock _coordTextBox;
        private readonly TextBlock _stationTextBox;
        private readonly TextBlock _weatherTextBox;
        private readonly CurrentLocationWeatherViewController _viewController;
        private Button _button;

        public MainPage()
        {
            InitializeComponent();

            _coordTextBox = new TextBlock
                {
                    Text = "Coords",
                    Margin = new Thickness(10, 0, 0, 0)
                };
            _stationTextBox = new TextBlock
                {
                    Text = "Station",
                    Margin = new Thickness(10, 30, 0, 0)
                };
            _weatherTextBox = new TextBlock
                {
                    Text = "Weather",
                    Margin = new Thickness(10, 60, 0, 0)
                };
            _button = new Button
                {
                    Height = 80,
                    Content = "Fetch",
                    Margin = new Thickness(10, 90, 0, 0),
                    Background = new SolidColorBrush(Color.FromArgb(200, 200, 200, 255))
                };

            _button.Tap += (sender, args) => _viewController.FetchPosition();

            ContentPanel.Children.Add(_coordTextBox);
            ContentPanel.Children.Add(_stationTextBox);
            ContentPanel.Children.Add(_weatherTextBox);
            ContentPanel.Children.Add(_button);

            _viewController = new CurrentLocationWeatherViewController(this);
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