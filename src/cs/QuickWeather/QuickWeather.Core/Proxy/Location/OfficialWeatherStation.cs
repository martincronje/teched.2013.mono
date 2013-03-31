using System.Runtime.Serialization;

namespace QuickWeather.Core.Proxy.Location
{
    public class OfficialWeatherStation
    {
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Icao { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
    }
}