using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QuickWeather.Proxy.Location
{
    [DataContract]
    public class LocationResponse
    {
        [DataMember(Name = "location")]
        public Location Location { get; set; }
    }

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

    [DataContract]
    public class WeatherStations
    {
        [DataMember(Name = "airport")]
        public List<OfficialWeatherStation> Official { get; set; }

        [DataMember(Name = "pws")]
        public List<UnofficialWeatherStation> Unofficial { get; set; }
    }

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
