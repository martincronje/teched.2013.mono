using System;
using System.Collections.Generic;

namespace QuickWeather.Core.Model
{
    public class ForecastDays : List<ForecastDay> { }

    public class ForecastDay
    {
        public DateTime Date { get; set; }
        public int Period { get; set; }
        public int High { get; set; }
        public int Low { get; set; }
        public string Conditions { get; set; }
        public string Icon { get; set; }
        public string ProbabilityOfPrecipitation { get; set; }
        public int AveHumidity { get; set; }
    }
}