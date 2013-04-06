using System.Runtime.Serialization;

namespace QuickWeather.Core.Proxy.Location
{
    public class Location
    {
        public string Type { get; set; }
        public string CountryIso3166 { get; set; }
        public string CountryName { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public WeatherStations NearbyWeatherStations { get; set; }
    }
}