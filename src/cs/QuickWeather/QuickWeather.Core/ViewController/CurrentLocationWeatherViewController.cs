using System;
using System.Threading;
using System.Threading.Tasks;
using QuickWeather.Core.Model;
using QuickWeather.Core.Proxy;
using Xamarin.Geolocation;

namespace QuickWeather.Core.ViewController
{
    public interface ICurrentLocationWeatherView
    {
        void DisplayCurrentLocation(GeoLocation geoLocation);
        void DisplayClosestWeatherStations(OfficialStations stations);
        void DisplayForecast(ForecastDays forecastDays);
        void DisplayError(Exception exception);
    }

    public partial class CurrentLocationWeatherViewController
    {
        private readonly ICurrentLocationWeatherView _view;
        private readonly Geolocator _geolocator;
        private readonly TaskScheduler _scheduler;
        private CancellationTokenSource _cancelSource;
        private GeoLocation _currentGeoLocation;

        public void FetchLocations(GeoLocation geoLocation)
        {
            var service = new WUndergroundProxy();
            var callback = new ServiceCallback<OfficialStations>(HandleLocationsReceived, HandleError);
            service.LookupStationsAsync(geoLocation.Latitude, geoLocation.Longitude, callback);
        }

        public void FetchWeather(GeoLocation geoLocation)
        {
            var proxy = new WUndergroundProxy();
            var callback = new ServiceCallback<ForecastDays>(HandleForecastReceived, HandleError);
            proxy.LookupForecastAsync(geoLocation.Latitude, geoLocation.Longitude, callback);
        }

        public void FetchPosition()
        {
            if (!_geolocator.IsGeolocationAvailable )
            {
                _view.DisplayError(new Exception("Geolocation disabled"));
                return;
            }

            _cancelSource = new CancellationTokenSource();

            _geolocator.GetPositionAsync(timeout: 20000, cancelToken: this._cancelSource.Token,
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
                            _currentGeoLocation = new GeoLocation(
                                t.Result.Timestamp,
                                t.Result.Latitude,
                                t.Result.Longitude);
                        
                            _view.DisplayCurrentLocation(_currentGeoLocation);
                        }

                    }, _scheduler);
        }


        private void HandleLocationsReceived(OfficialStations stations)
        {
            _view.DisplayClosestWeatherStations(stations);
        }
        private void HandleForecastReceived(ForecastDays forecast)
        {
            _view.DisplayForecast(forecast);
        }

        private void HandleError(Exception exception)
        {
            _view.DisplayError(exception);
        }

    }

}
