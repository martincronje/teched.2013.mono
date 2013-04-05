using System;
using System.Diagnostics;
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
        protected UILabel StationLabel { get; private set; }
        protected UILabel Icon { get; private set; }
        protected UIButton Button { get; set; }
        protected UILabel TempLowLabel { get; set; }
        protected UILabel TempHighLabel { get; set; }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _viewController = new CurrentLocationWeatherViewController(this);

            SetupView();
            SetupButton();
            SetupIcon();
            SetupLabels();
            SetupStation();

            //foreach (var s1 in UIFont.FamilyNames.OrderBy(c => c))
            //{
            //    Debug.WriteLine("{0} => {1}", s1, String.Join(", ", UIFont.FontNamesForFamilyName(s1)));
            //}
        }

        private void SetupLabels()
        {

            TempLowLabel = new UILabel()
                {
                    TextColor = UIColor.White,
                    BackgroundColor = UIColor.Clear,
                    Text = "low: 0",
                    Font = UIFont.FromName("Euphemia UCAS", 16.0f),
                    Frame = new RectangleF(10, 30, (Icon.Frame.Width / 2) - 10, 30),
                    AutoresizingMask = UIViewAutoresizing.FlexibleRightMargin ,
                    TextAlignment = UITextAlignment.Left,
                    AdjustsFontSizeToFitWidth = false

                };
            View.AddSubview(TempLowLabel);


            TempHighLabel = new UILabel()
                {
                    TextColor = UIColor.White,
                    BackgroundColor = UIColor.Clear,
                    Text = "high: 0",
                    Font = UIFont.FromName("Euphemia UCAS", 16.0f),
                    Frame = new RectangleF((Icon.Frame.Width / 2), 30, (Icon.Frame.Width / 2) - 10, 30),
                    AutoresizingMask = UIViewAutoresizing.FlexibleLeftMargin,
                    TextAlignment = UITextAlignment.Right,
                    AdjustsFontSizeToFitWidth = false

                };
            View.AddSubview(TempHighLabel);
        }

        private void SetupStation()
        {
            StationLabel = new UILabel(new RectangleF(0, 30, 300, 30))
                {
                    Frame = new RectangleF(0, 0, View.Frame.Width, 30),
                    TextColor = UIColor.White,
                    Text = "no station",
                    BackgroundColor = UIColor.FromRGBA(0, 0, 0, 75),
                    Font = UIFont.FromName("Euphemia UCAS", 20) ,
                    TextAlignment = UITextAlignment.Center
                };
            View.AddSubview(StationLabel);
        }

        private void SetupIcon()
        {
            Icon = new UILabel();

            Icon.Frame = new RectangleF(10, ((View.Frame.Height - View.Frame.Width)/2) - 30, View.Frame.Width - 20, View.Frame.Width);
            Icon.TextColor = UIColor.White;
            Icon.BackgroundColor = UIColor.Clear;
            Icon.Font = UIFont.FromName("Meteocons", 320.0f);
            Icon.Text = "B";
            Icon.AdjustsFontSizeToFitWidth = true;
            Button.AutoresizingMask = UIViewAutoresizing.FlexibleTopMargin | UIViewAutoresizing.FlexibleBottomMargin;

            View.AddSubview(Icon);
        }

        private void SetupButton()
        {
            Button = new UIButton(UIButtonType.Custom);

            Button.Frame = new RectangleF(0, View.Frame.Height - 60, View.Frame.Width, 60);
            Button.AutoresizingMask = UIViewAutoresizing.FlexibleTopMargin | UIViewAutoresizing.FlexibleWidth;
            Button.TouchDown += (sender, args) =>
            {
                Button.BackgroundColor = UIColor.FromRGBA(0,0,0,75);
            };
            Button.TouchCancel += (sender, args) =>
            {
                Button.BackgroundColor = UIColor.FromRGBA(0, 0, 0, 170);
            }; 
            Button.TouchUpInside += (sender, args) =>
            {
                _viewController.FetchPosition();
                Button.BackgroundColor = UIColor.FromRGBA(0, 0, 0, 170);
            };
            Button.SetTitleColor(UIColor.White, UIControlState.Normal);
            Button.SetTitle("(", UIControlState.Normal);
            Button.BackgroundColor = UIColor.FromRGBA(0, 0, 0, 170);
            Button.Font = UIFont.FromName("Meteocons", 30.0f);

            View.AddSubview(Button);
        }

        private void SetupView()
        {
            View.Frame = UIScreen.MainScreen.Bounds;
            View.BackgroundColor = UIColor.FromRGB(0, 149, 137);

            View.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
        }

        public void DisplayCurrentLocation(GeoLocation geoLocation)
        {
            InvokeOnMainThread(() =>
            {
                StationLabel.Text = string.Format("searching station for {0}", geoLocation.ToFriendlyString());
            });
            _viewController.FetchLocations(geoLocation);
        }

        public void DisplayClosestWeatherStations(OfficialStations stations)
        {
            var station = stations.First();

            InvokeOnMainThread(()=> 
            {
                StationLabel.Text = string.Format("{0}, {1} ({2})", station.City, station.Country, station.Location.ToFriendlyString());
            });

            _viewController.FetchWeather(station.Location);
        }

        public void DisplayForecast(ForecastDays forecast)
        {
            InvokeOnMainThread(() =>
                {
                    var forecastDay = forecast.First();

                    TempHighLabel.Text = string.Format("high: {0}", forecastDay.High);
                    TempLowLabel.Text = string.Format("low: {0}", forecastDay.Low);

                    UIView.Animate(2, () =>
                        {
                            if (forecastDay.High >= 30)
                                View.BackgroundColor = UIColor.FromRGB(207, 68, 0);
                            else if (forecastDay.High >= 24)
                                View.BackgroundColor = UIColor.FromRGB(207, 141, 0);
                            else if (forecastDay.High >= 21)
                                View.BackgroundColor = UIColor.FromRGB(0, 149, 137);
                            else if (forecastDay.High >= 15)
                                View.BackgroundColor = UIColor.FromRGB(0, 117, 207);
                            else if (forecastDay.High >= 10)
                                View.BackgroundColor = UIColor.FromRGB(0, 156, 207);
                            else
                                View.BackgroundColor = UIColor.FromRGB(0, 195, 207);

                            //Sweaty, hot weather	30+°C	85+°F
                            //T-shirt & shorts weather	24°C	75°F
                            //Average Room Temperature	21°C	70°F
                            //Long-sleeve shirt & pants weather	15°C	60°F
                            //Fleece jacket weather	10°C	50°F
                            //Freezing	0°C	32°F
                            //So cold you may want to reconsider going outside, especially with children	-29°C	-20°F

                            switch (forecastDay.Icon)
                            {
                                case "chanceflurries":
                                case "chancesleet":
                                case "flurries":
                                case "sleet":
                                    Icon.Text = "X";
                                    break;
                                case "chancerain":
                                case "rain":
                                    Icon.Text = "R";
                                    break;
                                case "chancesnow":
                                case "snow":
                                    Icon.Text = "W";
                                    break;
                                case "chancetstorms":
                                case "tstorms":
                                    Icon.Text = "O";
                                    break;
                                case "unknown":
                                case "sunny":
                                case "clear":
                                    Icon.Text = "B";
                                    break;
                                case "cloudy":
                                    Icon.Text = "Y";
                                    break;
                                case "fog":
                                    Icon.Text = "M";
                                    break;
                                case "hazy":
                                    Icon.Text = "J";
                                    break;
                                case "mostlycloudy":
                                case "partlycloudy":
                                    Icon.Text = "Y";
                                    break;
                                case "mostlysunny":
                                case "partlysunny":
                                    Icon.Text = "H";
                                    break;
                            }



                        });



                });
        }

        public void DisplayError(Exception exception)
        {
            InvokeOnMainThread(() =>
            {
                StationLabel.Text = string.Format("error: {0}", exception.Message);
            });
        }
    }
}

