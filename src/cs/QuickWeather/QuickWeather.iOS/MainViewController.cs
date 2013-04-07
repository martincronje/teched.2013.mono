using System;
using MonoTouch.UIKit;
using QuickWeather.Core.Model;
using QuickWeather.Core.Services;
using QuickWeather.Core.ViewController;

namespace QuickWeather.iOS
{
    public partial class MainViewController : UIViewController, ICurrentLocationWeatherView
    {
        private CurrentLocationWeatherViewController _controller;
        protected UILabel MessageLabel { get; private set; }
        protected UIButton Button { get; set; }
        protected UILabel TempLowLabel { get; set; }
        protected UILabel TempHighLabel { get; set; }
        protected UILabel Icon { get; private set; }

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
            System.Diagnostics.Debug.WriteLine("DisplayForecast" + System.Threading.Thread.CurrentThread.ManagedThreadId);
            InvokeOnMainThread(() =>
                {
                    System.Diagnostics.Debug.WriteLine("DisplayForecast" +
                                                       System.Threading.Thread.CurrentThread.ManagedThreadId);
                    TempHighLabel.Text = string.Format("high: {0}°", forecastDay.High);
                    TempLowLabel.Text = string.Format("low: {0}°", forecastDay.Low);

                    UIView.Animate(2, () =>
                        {
                            var color = _controller.GetTemperatureColour(forecastDay.High);
                            View.BackgroundColor = UIColor.FromRGB(color.Red, color.Green, color.Blue);
                            Icon.Text = _controller.GetMeteoconCharacter(forecastDay);
                        });
                });
        }


        public void DisplayError(Exception exception)
        {
            InvokeOnMainThread(() =>
                {
                    MessageLabel.Text = string.Format("error: {0}", exception.Message);
                });
        }

        public void DisplayProgressUpdate(string message)
        {
            System.Diagnostics.Debug.WriteLine("DisplayProgressUpdate" +
                                               System.Threading.Thread.CurrentThread.ManagedThreadId);
            InvokeOnMainThread(() =>
                {
                    System.Diagnostics.Debug.WriteLine("DisplayProgressUpdate" +
                                                       System.Threading.Thread.CurrentThread.ManagedThreadId);
                    MessageLabel.Text = string.Format(message);
                });
        }
    }
}

