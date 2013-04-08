using System;
using Android.App;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using Android.OS;
using QuickWeather.Core.Model;
using QuickWeather.Core.Services;
using QuickWeather.Core.ViewController;

namespace QuickWeather.UI
{
    [Activity(Label = "Quick Weather", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, ICurrentLocationWeatherView
    {
        private CurrentLocationWeatherViewController _controller;
        private TextView _icon;
        private TextView _tempLowLabel;
        private TextView _tempHighLabel;
        private TextView _messageLabel;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            _controller = new CurrentLocationWeatherViewController(this, new WeatherServiceStub(), this);

            var button = FindViewById<Button>(Resource.Id.Button);
            button.Click += (sender, args) => _controller.FetchPosition();
            button.Typeface = Typeface.CreateFromAsset(this.Assets, "meteocons-webfont.ttf");

            _icon = FindViewById<TextView>(Resource.Id.Icon);
            _icon.Typeface = Typeface.CreateFromAsset(this.Assets, "meteocons-webfont.ttf");

            _tempHighLabel = FindViewById<TextView>(Resource.Id.TextViewTempHigh);
            _tempLowLabel = FindViewById<TextView>(Resource.Id.TextViewTempLow);
            _messageLabel = FindViewById<TextView>(Resource.Id.TextViewMessage);
        }

        public void DisplayForecast(ForecastDay forecastDay)
        {
            _tempHighLabel.Text = string.Format("high: {0}°", forecastDay.High);
            _tempLowLabel.Text = string.Format("low: {0}°", forecastDay.Low);
            _icon.Text = _controller.GetMeteoconCharacter(forecastDay);
        }

        public void DisplayError(Exception exception)
        {
            _messageLabel.Text = string.Format("error: {0}", exception.Message);
        }

        public void DisplayProgressUpdate(string message)
        {
            _messageLabel.Text = string.Format(message);
        }
    }
}

