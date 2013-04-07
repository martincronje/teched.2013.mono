using System.Collections.Generic;

namespace QuickWeather.Core.Services.Location
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