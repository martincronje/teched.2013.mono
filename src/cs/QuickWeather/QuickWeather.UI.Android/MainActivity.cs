using System;
using Android.App;
using Android.OS;
using QuickWeather.Core.Model;
using QuickWeather.Core.Services;
using QuickWeather.Core.ViewController;

namespace QuickWeather.UI
{
    [Activity(Label = "Quick Weather", MainLauncher = true, Icon = "@drawable/icon")]
    public partial class MainActivity : Activity, ICurrentLocationWeatherView
    {
        private CurrentLocationWeatherViewController _controller;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            InitializeComponent();

            SetContentView(Resource.Layout.Main);

            _controller = new CurrentLocationWeatherViewController(this, new WeatherServiceStub(), this);

            Button.Click += (sender, args) =>
            {
                _controller.FetchLocalWeather();
            };
        }

        public void DisplayForecast(ForecastDay forecastDay)
        {
            TempHighLabel.Text = string.Format("high: {0}°", forecastDay.High);
            TempLowLabel.Text = string.Format("low: {0}°", forecastDay.Low);
            Icon.Text = _controller.GetMeteoconCharacter(forecastDay);
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

