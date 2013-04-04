using System;
using System.Linq;
using MonoTouch.UIKit;
using System.Drawing;
using QuickWeather.Core.Model;
using QuickWeather.Core.ViewController;

namespace QuickWeather.iOS
{
    public class MainViewController : UIViewController, ICurrentLocationWeatherView
    {
        private CurrentLocationWeatherViewController _viewController;
        private UILabel _coordLabel;
        private UILabel _stationLabel;
        private UILabel _weatherLabel;
        private UIButton _button;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _viewController = new CurrentLocationWeatherViewController(this);

            SetupView();
            SetupLabels();
        }

        private void SetupLabels()
        {
            _coordLabel = new UILabel(new RectangleF(10, 0, 300, 30));
            _stationLabel = new UILabel(new RectangleF(10, 30, 300, 30));
            _weatherLabel = new UILabel(new RectangleF(10, 60, 300, 30));

            _button = new UIButton(UIButtonType.RoundedRect);

            _button.Frame = new RectangleF(60, 90, 200, 40);
            _button.SetTitle("Fetch", UIControlState.Normal);
            _button.TouchUpInside += (sender, args) => _viewController.FetchPosition();

            View.AddSubview(_coordLabel);
            View.AddSubview(_stationLabel);
            View.AddSubview(_weatherLabel);
            View.AddSubview(_button);
        }

        private void SetupView()
        {
            View.Frame = UIScreen.MainScreen.Bounds;
            View.BackgroundColor = UIColor.White;
            View.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
        }

        public void DisplayCurrentLocation(GeoLocation geoLocation)
        {
            InvokeOnMainThread(() =>
            {
                _coordLabel.Text = string.Format("Coordinates {0}", geoLocation.ToFriendlyString());
            });
            _viewController.FetchLocations(geoLocation);
        }

        public void DisplayClosestWeatherStations(OfficialStations stations)
        {
            var station = stations.First();

            InvokeOnMainThread(()=> 
            {
                    _stationLabel.Text = string.Format("Station: {0}, {1}", station.City, station.Country);
            });

            _viewController.FetchWeather(station.Location);
        }

        public void DisplayForecast(ForecastDays forecast)
        {
            InvokeOnMainThread(() =>
            {
                var forecastDay = forecast.First();

                _weatherLabel.Text =  string.Format("Today High: {0}", forecastDay.High);
            });
        }

        public void DisplayError(Exception exception)
        {
            InvokeOnMainThread(() =>
            {
                _coordLabel.Text = string.Format("Error: {0}", exception.Message);
            });
        }
    }
}

