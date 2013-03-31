using System.Runtime.Serialization;

namespace QuickWeather.Proxy.Forecast
{
    [DataContract]
	public class ForecastResponse
	{
        [DataMember(Name="forecast")]
        public Forecast Forecast { get; set; }
	}
}

