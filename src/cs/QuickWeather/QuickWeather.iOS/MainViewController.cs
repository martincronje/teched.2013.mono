using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MonoTouch.UIKit;
using System.Drawing;
using QuickWeather.Core.Proxy;
using QuickWeather.Core.Proxy.Forecast;
using QuickWeather.Core.Proxy.Location;
using Xamarin.Geolocation;

namespace QuickWeather.iOS
{
    public class MainViewController : UIViewController
    {
        private UILabel _label;
        private CancellationTokenSource _cancelSource;
        private Geolocator _geolocator;
        private string _latitude;
        private string _longitude;
        private readonly TaskScheduler _scheduler = TaskScheduler.FromCurrentSynchronizationContext();

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            SetupView();
            SetupLabel();
            SetupGeo();
        }

        private void SetupLabel()
        {
            _label = new UILabel(new RectangleF(0, 0, 300, 30));

            View.AddSubview(_label);
        }

        private void SetupView()
        {
            View.Frame = UIScreen.MainScreen.Bounds;
            View.BackgroundColor = UIColor.White;
            View.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
        }

        private void SetupGeo()
        {
            if (this._geolocator != null)
                return;

            this._geolocator = new Geolocator {DesiredAccuracy = 50};
            //    this._geolocator.PositionError += OnListeningError;
            //    this._geolocator.PositionChanged += OnPositionChanged;
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            GetPosition();
        }

        private void FetchLocations()
        {
            var proxy = new WUndergroundProxy();

            Action<Location> onData =
                location =>
                    {
                        InvokeOnMainThread(delegate
                            {
                                _label.Text = location.NearbyWeatherStations.Airport.Station.First().City;
                            });
                        FetchWeather();
                    };

            var callback = new WUndergroundProxyCallback<Location>(onData, HandleError);
            proxy.LookupStationsAsync(_latitude, _longitude, callback);
        }

        private void FetchWeather()
        {
            var proxy = new WUndergroundProxy();

            var callback = new WUndergroundProxyCallback<Forecast>(HandleForecastReceived, HandleError);
            proxy.LookupForecastAsync(_latitude, _longitude, callback);
        }

        private void HandleForecastReceived(Forecast forecast)
        {
            InvokeOnMainThread(delegate
                {
                    var forecastDay = forecast.SimpleForecast.ForecastDay.FirstOrDefault();

                    if (forecastDay != null)
                        _label.Text = _label.Text + " High: " + forecastDay.High.Celsius;
                });
        }

        private void HandleError(Exception exception)
        {
            InvokeOnMainThread(delegate
                {
                    _label.Text = exception.Message;
                });
        }


        private void GetPosition()
        {
            this._cancelSource = new CancellationTokenSource();

            this._geolocator.GetPositionAsync(timeout: 10000, cancelToken: this._cancelSource.Token,
                                              includeHeading: true)
                .ContinueWith(t =>
                    {
                        if (t.IsFaulted)
                        {

                            _label.Text = ((GeolocationException) t.Exception.InnerException).Error.ToString();
                        }
                        else if (t.IsCanceled)
                        {

                            _label.Text = "Canceled";
                        }
                        else
                        {
                            _label.Text = t.Result.Timestamp.ToString("G");
                            _latitude = t.Result.Latitude.ToString("N4");
                            _longitude = t.Result.Longitude.ToString("N4");
                            FetchLocations();
                        }

                    }, _scheduler);
        }
    }
}

