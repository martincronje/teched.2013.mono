using System.Runtime.Serialization;

namespace QuickWeather.Proxy.Forecast
{
    [DataContract]
    public class Precipitation
    {
        [DataMember(Name = "in")]
        public decimal Inches { get; set; }

        [DataMember(Name = "mm")]
        public decimal Millimeters { get; set; }
    }
}