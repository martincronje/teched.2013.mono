using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QuickWeather.Proxy.Forecast
{
    [DataContract]
    public class TextForecast
    {
        [DataMember(Name = "date")]
        public string DateRaw { get; set; }

        [DataMember(Name = "forecastday")]
        public List<TextForecastDay> Days { get; set; }
    }
}