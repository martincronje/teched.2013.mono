using System.Runtime.Serialization;

namespace QuickWeather.Proxy.Forecast
{
    [DataContract]
    public class Forecast
    {
        [DataMember(Name = "txt_forecast")]
        public TextForecast TextForecast { get; set; }

        [DataMember(Name = "simpleforecast")]
        public SimpleForecast SimpleForecast { get; set; }
    }
}