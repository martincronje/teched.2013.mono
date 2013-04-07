using System.Collections.Generic;

namespace QuickWeather.Core.Model
{
    public class OfficialStations : List<OfficialStation> { }

    public class OfficialStation
    {
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string ICAO { get; set; }
        public GeoLocation Location { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1}", City, Country);
        }
    }
}