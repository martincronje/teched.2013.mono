using System.Runtime.Serialization;

namespace QuickWeather.Proxy.Forecast
{
    [DataContract]
    public class TextForecastDay
    {
        [DataMember(Name = "period")]
        public uint Period { get; set; }

        [DataMember(Name = "icon")]
        public string Icon { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "fcttext_metric")]
        public string Text { get; set; }
    }
}