using System;
using System.Linq;
using System.Threading.Tasks;
using MonoTouch.UIKit;
using System.Drawing;
using QuickWeather.Core;

namespace QuickWeather.iOS
{
    public class MainViewController : UIViewController
    {
        private UILabel _label;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.Frame = UIScreen.MainScreen.Bounds;
            View.BackgroundColor = UIColor.White;
            View.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;

            _label = new UILabel(new RectangleF(0, 0, 300, 30));

            View.AddSubview(_label);
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            var proxy = new WeatherUndergroundProxy();

            var stations = proxy.LookupStations("37.776289", "-122.395234");

            _label.Text = stations.NearbyWeatherStations.Airport.Station.First().City;

        }
    }
}

