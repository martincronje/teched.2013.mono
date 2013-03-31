using System.Collections.Generic;

namespace QuickWeather.Core.Proxy.Forecast
{
    public class TextForecast
    {
        public string Date { get; set; }
        public List<TextForecastDay> ForecastDay { get; set; }
    }
}