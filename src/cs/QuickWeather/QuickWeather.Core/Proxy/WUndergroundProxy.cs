using System;
using System.Threading;
using QuickWeather.Core.Proxy.Forecast;
using QuickWeather.Core.Proxy.Location;
using RestSharp;

namespace QuickWeather.Core.Proxy
{
    public class WUndergroundProxyCallback<T>
    {
        public WUndergroundProxyCallback(Action<T> onData, Action<Exception> onError)
        {
            OnError = onError;
            OnData = onData;
        }

        public Action<Exception> OnError { get; private set; }
        public Action<T> OnData { get; private set; }
    }

    public class WUndergroundProxy
    {
        private readonly RestClient _restClient;

        public WUndergroundProxy()
        {
            _restClient = new RestClient("http://api.wunderground.com/api/1ee1456e1469d243");
        }

        public void LookupStationsAsync(string latitude, string longitude, WUndergroundProxyCallback<Location.Location> callback)
        {
            var path = string.Format("geolookup/q/{0},{1}.json", latitude, longitude);
            var request = new RestRequest(path, Method.GET);

            _restClient.ExecuteAsync<LocationResponse>(request, (response, handle) =>
            {
                if (response.ErrorException != null)
                    callback.OnError(response.ErrorException);
                else
                    callback.OnData(response.Data.Location);
            });
        }

        public void LookupForecastAsync(string latitude, string longitude, WUndergroundProxyCallback<Forecast.Forecast> callback)
        {
            var path = string.Format("forecast/q/{0},{1}.json", latitude, longitude);
            var request = new RestRequest(path, Method.GET);

            _restClient.ExecuteAsync<ForecastResponse>(request, (response, handle) =>
            {
                if (response.ErrorException != null)
                    callback.OnError(response.ErrorException);
                else
                    callback.OnData(response.Data.Forecast);
            });

        }

        public Forecast.Forecast LookupForecast(string latitude, string longitude)
        {
            return LookupSync<Forecast.Forecast>(callback => LookupForecastAsync(latitude, longitude, callback));
        }

        public Location.Location LookupStations(string latitude, string longitude)
        {
            return LookupSync<Location.Location>(callback => LookupStationsAsync(latitude, longitude, callback));
        }

        private static T LookupSync<T>(Action<WUndergroundProxyCallback<T>> call)
        {
            var retval = default(T);
            Exception returnException = null;

            var resetEvent = new ManualResetEvent(false);

            Action<T> onData = location =>
                {
                    retval = location;
                    resetEvent.Set();
                };
            Action<Exception> onError = exception =>
                {
                    returnException = exception;
                    resetEvent.Set();
                };

            var callback = new WUndergroundProxyCallback<T>(onData, onError);

            call(callback);

            resetEvent.WaitOne();

            if (returnException != null)
                throw new Exception("Async execution failed. See inner exception for details.", returnException);

            return retval;
        }
    }
}