using System.Collections.Generic;

namespace QuickWeather.Core.Services.Forecast
{
    public class TextForecast
    {
        public string Date { get; set; }
        public List<TextForecastDay> ForecastDay { get; set; }
    }
}