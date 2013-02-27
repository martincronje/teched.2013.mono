using System.Runtime.Serialization;

namespace QuickWeather.Proxy.Forecast
{
    [DataContract]
    public class Temperature
    {
        [DataMember(Name = "fahrenheit")]
        public string Fahrenheit { get; set; }

        [DataMember(Name = "celsuis")]
        public string Celsuis { get; set; }
    }
}