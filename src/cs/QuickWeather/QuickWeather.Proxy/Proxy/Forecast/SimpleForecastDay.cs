using System.Runtime.Serialization;

namespace QuickWeather.Proxy.Forecast
{
    [DataContract]
    public class SimpleForecastDay
    {
        [DataMember(Name = "date")]
        public ForecastDate Date { get; set; }

        [DataMember(Name = "period")]
        public int Period { get; set; }

        [DataMember(Name = "high")]
        public Temperature High { get; set; }

        [DataMember(Name = "low")]
        public Temperature Low { get; set; }

        [DataMember(Name = "conditions")]
        public string Conditions { get; set; }

        [DataMember(Name = "icon")]
        public string Icon { get; set; }

        [DataMember(Name = "pop")]
        public string ProbabilityOfPrecipitation { get; set; }

        [DataMember(Name = "qpf_allday")]
        public Precipitation QpfAllDay { get; set; }

        [DataMember(Name = "qpf_day")]
        public Precipitation QpfDay { get; set; }

        [DataMember(Name = "qpf_night")]
        public Precipitation QpfNight { get; set; }

        [DataMember(Name = "snow_allday")]
        public Precipitation SnowAllDay { get; set; }

        [DataMember(Name = "snow_day")]
        public Precipitation SnowDay { get; set; }

        [DataMember(Name = "snow_night")]
        public Precipitation SnowNight { get; set; }

        [DataMember(Name = "avehumidity")]
        public int AverageHumidity { get; set; }

        [DataMember(Name = "maxhumidity")]
        public int MaxHumidity { get; set; }

        [DataMember(Name = "minhumidity")]
        public int MinHumidity { get; set; }

    }
}