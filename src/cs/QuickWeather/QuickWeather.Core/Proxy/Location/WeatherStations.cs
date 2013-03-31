using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QuickWeather.Core.Proxy.Location
{
    public class WeatherStations
    {
        public StationCollection<OfficialWeatherStation> Airport { get; set; }
        public StationCollection<UnofficialWeatherStation> Pws { get; set; }
    }

    public class StationCollection<T>
    {
        public List<T> Station { get; set; }
    }
}