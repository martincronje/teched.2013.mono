using System.Runtime.Serialization;

namespace QuickWeather.Proxy.Location
{
    public class UnofficialWeatherStation
    {
        [DataMember(Name = "neighbourhood")]
        public string Neighborhood { get; set; }

        [DataMember(Name = "country")]
        public string Country { get; set; }

        [DataMember(Name = "state")]
        public string State { get; set; }

        [DataMember(Name = "city")]
        public string City { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "lat")]
        public decimal Latitude { get; set; }

        [DataMember(Name = "lon")]
        public decimal Longtitude { get; set; }

        [DataMember(Name = "distance_km")]
        public int Distance { get; set; }
    }
}