using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QuickWeather.Proxy.Forecast
{
    [DataContract]
    public class SimpleForecast
    {
        [DataMember(Name = "forecastday")]
        public List<SimpleForecastDay> Days { get; set; }
    }
}