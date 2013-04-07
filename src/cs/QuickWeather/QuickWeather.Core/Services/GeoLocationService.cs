using System;
using System.Threading;
using System.Threading.Tasks;
using QuickWeather.Core.Model;
using Xamarin.Geolocation;

namespace QuickWeather.Core.Services
{
    internal class GeoLocationService
    {
        private readonly Geolocator _geolocator;
        private readonly TaskScheduler _scheduler;
        private CancellationTokenSource _cancelSource;

        public GeoLocationService()
        {
            _geolocator = new Geolocator { DesiredAccuracy = 50 };
            _scheduler = TaskScheduler.FromCurrentSynchronizationContext();
        }

        public void GetPositionAsync(ServiceCallback<GeoLocation> callback)
        {

            if (!_geolocator.IsGeolocationAvailable)
            {
                callback.OnError(new Exception("Geolocation disabled"));
                return;
            }

            _cancelSource = new CancellationTokenSource();

            _geolocator.GetPositionAsync(timeout: 20000, cancelToken: this._cancelSource.Token,
                                         includeHeading: true)
                       .ContinueWith(t =>
                           {
                               if (t.IsFaulted)
                               {
                                   callback.OnError(t.Exception);
                               }
                               else if (t.IsCanceled)
                               {
                                   callback.OnError(new Exception("Geolocation lookup cancelled."));
                               }
                               else
                               {
                                   var geoLocation = new GeoLocation(t.Result.Timestamp, t.Result.Latitude, t.Result.Longitude);

                                   callback.OnData(geoLocation);
                               }
                           }, _scheduler);
        }
    }
}