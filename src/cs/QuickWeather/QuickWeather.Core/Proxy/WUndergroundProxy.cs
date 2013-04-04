using System;
using System.Threading;
using QuickWeather.Core.Model;
using QuickWeather.Core.Proxy.Forecast;
using QuickWeather.Core.Proxy.Location;
using RestSharp;

namespace QuickWeather.Core.Proxy
{
    public class WUndergroundProxy
    {
        private readonly RestClient _restClient;

        public WUndergroundProxy()
        {
            _restClient = new RestClient("http://api.wunderground.com/api/1ee1456e1469d243");
        }

        public void LookupStationsAsync(double latitude, double longitude, ServiceCallback<OfficialStations> callback)
        {
            var path = BuildCoordinateQuery("geolookup", latitude, longitude);
            var request = new RestRequest(path, Method.GET);

            _restClient.ExecuteAsync<LocationResponse>(request, (response, handle) =>
            {
                if (response.ErrorException != null)
                    callback.OnError(response.ErrorException);
                else
                {
                    var stations = BuildWeatherStations(response.Data.Location);
                    callback.OnData(stations);
                }
            });
        }

        public void LookupForecastAsync(double latitude, double longitude, ServiceCallback<ForecastDays> callback)
        {
            var path = BuildCoordinateQuery("forecast", latitude, longitude);
            var request = new RestRequest(path, Method.GET);

            _restClient.ExecuteAsync<ForecastResponse>(request, (response, handle) =>
            {
                if (response.ErrorException != null)
                    callback.OnError(response.ErrorException);
                else
                {
                    var days = BuildWeatherForecatDays(response.Data.Forecast);
                    callback.OnData(days);
                }
            });

        }

        private static string BuildCoordinateQuery(string resource, double latitude, double longitude)
        {
            return string.Format("{0}/q/{1},{2}.json", resource, latitude.ToString("N4"), longitude.ToString("N4"));
        }

        public ForecastDays LookupForecast(double latitude, double longitude)
        {
            return LookupSync<ForecastDays>(callback => LookupForecastAsync(latitude, longitude, callback));
        }

        public OfficialStations LookupStations(double latitude, double longitude)
        {
            return LookupSync<OfficialStations>(callback => LookupStationsAsync(latitude, longitude, callback));
        }

        private static T LookupSync<T>(Action<ServiceCallback<T>> call)
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

            var callback = new ServiceCallback<T>(onData, onError);

            call(callback);

            resetEvent.WaitOne();

            if (returnException != null)
                throw new Exception("Async execution failed. See inner exception for details.", returnException);

            return retval;
        }

        private OfficialStations BuildWeatherStations(Location.Location response)
        {
            if (response == null) return null;
            if (response.NearbyWeatherStations == null) return null;
            if (response.NearbyWeatherStations.Airport == null) return null;
            if (response.NearbyWeatherStations.Airport.Station == null) return null;

            var stations = new OfficialStations();

            foreach (var station in response.NearbyWeatherStations.Airport.Station)
            {
                stations.Add(new OfficialStation
                {
                    City = station.City,
                    Country = station.Country,
                    ICAO = station.Icao,
                    Location = new GeoLocation(double.Parse(station.Lat), double.Parse(station.Lon))
                });
            }
            return stations;
        }

        private ForecastDays BuildWeatherForecatDays(Forecast.Forecast response)
        {
            if (response == null) return null;
            if (response.SimpleForecast == null) return null;
            if (response.SimpleForecast.ForecastDay == null) return null;

            var days = new ForecastDays();

            foreach (var forecastDay in response.SimpleForecast.ForecastDay)
            {
                days.Add(new ForecastDay
                    {
                        Date = FromUnixTime( long.Parse(forecastDay.Date.Epoch)),
                        Period = forecastDay.Period,
                        High = int.Parse( forecastDay.High.Celsius),
                        Low = int.Parse(forecastDay.Low.Celsius),
                        Conditions = forecastDay.Conditions,
                        Icon = forecastDay.Icon,
                        ProbabilityOfPrecipitation = forecastDay.Pop,
                        AveHumidity = forecastDay.AveHumidity
                    });
            }
            return days;
        }

        public DateTime FromUnixTime(long unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime);
        }
    }
}