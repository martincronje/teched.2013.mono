using System;
using MonoTouch.UIKit;
using QuickWeather.Core.Model;
using QuickWeather.Core.Services;
using QuickWeather.Core.ViewController;

namespace QuickWeather.UI
{
    public partial class MainViewController : UIViewController, ICurrentLocationWeatherView
    {
        private CurrentLocationWeatherViewController _controller;
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            InitializeComponent();

            _controller = new CurrentLocationWeatherViewController(this, new WeatherServiceStub());

            Button.TouchUpInside += (sender, args) =>
                {
                    _controller.FetchLocalWeather();
                };
        }

        public void DisplayForecast(ForecastDay forecastDay)
        {
            TempHighLabel.Text = string.Format("high: {0}°", forecastDay.High);
            TempLowLabel.Text = string.Format("low: {0}°", forecastDay.Low);

            Icon.Text = _controller.GetMeteoconCharacter(forecastDay);

            var color = _controller.GetTemperatureColour(forecastDay.High);
            View.BackgroundColor = UIColor.FromRGB(color.Red, color.Green, color.Blue);
        }

        public void DisplayError(Exception exception)
        {
            MessageLabel.Text = string.Format("error: {0}", exception.Message);
        }

        public void DisplayProgressUpdate(string message)
        {
            MessageLabel.Text = string.Format(message);
        }
    }
}

