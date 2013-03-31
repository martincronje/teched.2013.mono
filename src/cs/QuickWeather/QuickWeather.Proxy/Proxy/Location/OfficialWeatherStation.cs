using System.Runtime.Serialization;

namespace QuickWeather.Proxy.Location
{
    public class OfficialWeatherStation
    {
        [DataMember(Name = "country")]
        public string Country { get; set; }

        [DataMember(Name = "state")]
        public string State { get; set; }

        [DataMember(Name = "city")]
        public string City { get; set; }

        [DataMember(Name = "icao")]
        public string Icao { get; set; }

        [DataMember(Name = "lat")]
        public string Latitude { get; set; }

        [DataMember(Name = "lon")]
        public string Longtitude { get; set; }
    }
}