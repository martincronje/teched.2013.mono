using System;

namespace QuickWeather.Core.Model
{
    public class GeoLocation
    {
        public GeoLocation(DateTimeOffset date, double latitude, double longitude)
        {
            Longitude = longitude;
            Latitude = latitude;
            Date = date;
        }

        public GeoLocation(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double Longitude { get; private set; }
        public double Latitude { get; private set; }
        public DateTimeOffset Date { get; private set; }

        public string ToFriendlyString()
        {
            return string.Format("{0}, {1}", Latitude.ToString("N4"), Longitude.ToString("N4"));
        }
    }
}
