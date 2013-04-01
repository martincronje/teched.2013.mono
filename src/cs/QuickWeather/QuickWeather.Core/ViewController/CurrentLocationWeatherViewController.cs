using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using QuickWeather.Core.Proxy;
using QuickWeather.Core.Proxy.Forecast;
using QuickWeather.Core.Proxy.Location;
using Xamarin.Geolocation;

namespace QuickWeather.Core.ViewController
{
    public interface ICurrentLocationWeatherView
    {
        void DisplayCurrentLocation(double latitude, double longitude, DateTimeOffset timestamp);
        void DisplayClosestWeatherStations(Location location);
        void DisplayForecast(Forecast forecast);
        void DisplayError(Exception exception);
    }

    public class CurrentLocationWeatherViewController
    {
        private readonly ICurrentLocationWeatherView _view;
        private readonly Geolocator _geolocator;
        private readonly TaskScheduler _scheduler;
        private CancellationTokenSource _cancelSource;

        private double _latitude;
        private double _longitude;
        private DateTimeOffset _timestamp;

        public CurrentLocationWeatherViewController(ICurrentLocationWeatherView view)
        {
            _view = view;
            _scheduler = TaskScheduler.FromCurrentSynchronizationContext();
            _geolocator = new Geolocator {DesiredAccuracy = 50};
        }

        private void FetchLocations()
        {
            var proxy = new WUndergroundProxy();
            var callback = new WUndergroundProxyCallback<Location>(HandleLocationsReceived, HandleError);
            proxy.LookupStationsAsync(_latitude, _longitude, callback);
        }

        private void FetchWeather()
        {
            var proxy = new WUndergroundProxy();
            var callback = new WUndergroundProxyCallback<Forecast>(HandleForecastReceived, HandleError);
            proxy.LookupForecastAsync(_latitude, _longitude, callback);
        }

        private void FetchPosition()
        {
            this._cancelSource = new CancellationTokenSource();

            this._geolocator.GetPositionAsync(timeout: 10000, cancelToken: this._cancelSource.Token,
                                              includeHeading: true)
                .ContinueWith(t =>
                    {
                        if (t.IsFaulted)
                        {
                            _view.DisplayError(t.Exception);
                        }
                        else if (t.IsCanceled)
                        {
                            _view.DisplayError(new Exception("Geolocation lookup cancelled."));
                        }
                        else
                        {
                            _timestamp = t.Result.Timestamp;//.ToString("G");
                            _latitude = t.Result.Latitude;//.ToString("N4");
                            _longitude = t.Result.Longitude;//.ToString("N4");

                            _view.DisplayCurrentLocation(_latitude, _latitude, _timestamp);

                            FetchLocations();
                        }

                    }, _scheduler);
        }


        private void HandleLocationsReceived(Location location)
        {
            if (location == null)
                return;

            _view.DisplayClosestWeatherStations(location);
            //InvokeOnMainThread(delegate
            //{
            //    var forecastDay = forecast.SimpleForecast.ForecastDay.FirstOrDefault();

            //    if (forecastDay != null)
            //        _label.Text = _label.Text + " High: " + forecastDay.High.Celsius;
            //});
        }
        private void HandleForecastReceived(Forecast forecast)
        {
            if (forecast == null)
                return;

            _view.DisplayForecast(forecast);

            //InvokeOnMainThread(delegate
            //{
            //    var forecastDay = forecast.SimpleForecast.ForecastDay.FirstOrDefault();

            //    if (forecastDay != null)
            //        _label.Text = _label.Text + " High: " + forecastDay.High.Celsius;
            //});
        }

        private void HandleError(Exception exception)
        {
            if (exception == null)
                return;

            _view.DisplayError(exception);
        }

    }

}
