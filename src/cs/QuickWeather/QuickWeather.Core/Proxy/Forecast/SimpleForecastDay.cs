namespace QuickWeather.Core.Proxy.Forecast
{
    public class SimpleForecastDay
    {
        public ForecastDate Date { get; set; }
        public int Period { get; set; }
        public Temperature High { get; set; }
        public Temperature Low { get; set; }
        public string Conditions { get; set; }
        public string Icon { get; set; }
        public string Pop { get; set; }
        public Precipitation QpfAllday { get; set; }
        public Precipitation QpfDay { get; set; }
        public Precipitation QpfNight { get; set; }
        public Precipitation SnowAllday { get; set; }
        public Precipitation SnowDay { get; set; }
        public Precipitation SnowNight { get; set; }
        public int AveHumidity { get; set; }
        public int MaxHumidity { get; set; }
        public int MinHumidity { get; set; }
    }
}