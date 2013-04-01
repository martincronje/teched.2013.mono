using System.Runtime.Serialization;

namespace QuickWeather.Proxy.Location
{
    [DataContract]
    public class Location
    {
        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "cpuntry_iso3166")]
        public string CountryCode { get; set; }

        [DataMember(Name = "country_name")]
        public string Country { get; set; }

        [DataMember(Name = "state")]
        public string State { get; set; }

        [DataMember(Name = "city")]
        public string City { get; set; }

        [DataMember(Name = "nearby_weather_stations")]
        public WeatherStations WeatherStations { get; set; }
    }
}