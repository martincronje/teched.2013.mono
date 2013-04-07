using System;
using QuickWeather.Core.Model;

namespace QuickWeather.Core.ViewController
{
    public interface ICurrentLocationWeatherView
    {
        void DisplayForecast(ForecastDay forecastDay);
        void DisplayError(Exception exception);
        void DisplayProgressUpdate(string message);
    }
}