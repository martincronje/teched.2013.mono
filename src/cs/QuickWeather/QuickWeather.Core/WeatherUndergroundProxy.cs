using QuickWeather.Core.Proxy.Location;
using RestSharp;

namespace QuickWeather.Core
{
    public class WeatherUndergroundProxy
    {
        private readonly RestClient _restClient;

        public WeatherUndergroundProxy()
        {
            _restClient = new RestClient("http://api.wunderground.com/api/1ee1456e1469d243");
        }

        public Location LookupStations(string latitude, string longitude)
        {
            var path = string.Format("geolookup/q/{0},{1}.json", latitude, longitude);
            var request = new RestRequest(path, Method.GET);
            var response = _restClient.Execute<LocationResponse>(request);

            if (response.ErrorException != null)
                throw response.ErrorException;

            return response.Data.Location;
        }
    }
}
