using System.Runtime.Serialization;

namespace QuickWeather.Proxy.Forecast
{
    [DataContract]
    public class ForecastDate
    {
        [DataMember(Name = "epoch")]
        public string Epoch { get; set; }
    }
}