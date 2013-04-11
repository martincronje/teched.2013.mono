using System;
using System.Windows.Media;
using QuickWeather.Core.Model;
using QuickWeather.Core.Services;
using QuickWeather.Core.ViewController;

namespace QuickWeather.UI
{
    public partial class MainPage : ICurrentLocationWeatherView
    {
        private readonly CurrentLocationWeatherViewController _controller;

        public MainPage()
        {
            InitializeComponent();

            Button.Tap += (sender, args) => _controller.FetchPosition();

            _controller = new CurrentLocationWeatherViewController(this, new WeatherServiceStub());
        }

        public void DisplayForecast(ForecastDay forecastDay)
        {
            TempHighLabel.Text = string.Format("high: {0}°", forecastDay.High);
            TempLowLabel.Text = string.Format("low: {0}°", forecastDay.Low);

            var color = _controller.GetTemperatureColour(forecastDay.High);
            LayoutRoot.Background = new SolidColorBrush(Color.FromArgb(255, color.Red, color.Green, color.Blue));

            Icon.Text = _controller.GetMeteoconCharacter(forecastDay);
        }

        public void DisplayError(Exception exception)
        {
            MessageLabel.Text = string.Format("Error: {0}", exception.Message);
        }

        public void DisplayProgressUpdate(string message)
        {
            MessageLabel.Text = message;
        }
    }
}