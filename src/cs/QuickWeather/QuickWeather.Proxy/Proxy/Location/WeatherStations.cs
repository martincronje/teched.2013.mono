using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QuickWeather.Proxy.Location
{
    [DataContract]
    public class WeatherStations
    {
        [DataMember(Name = "airport")]
        public List<OfficialWeatherStation> Official { get; set; }

        [DataMember(Name = "pws")]
        public List<UnofficialWeatherStation> Unofficial { get; set; }
    }
}