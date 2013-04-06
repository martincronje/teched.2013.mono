using System;
using System.Threading.Tasks;
using QuickWeather.Core.Model;

namespace QuickWeather.Core.Proxy
{
    public class WeatherServiceStub : IWeatherService
    {
        public void LookupStationsAsync(double latitude, double longitude, ServiceCallback<OfficialStations> callback)
        {
            throw new NotImplementedException();
        }

        public void LookupForecastAsync(double latitude, double longitude, ServiceCallback<ForecastDays> callback)
        {

          //  Task.Factory.StartNew(() =>
          //      {
                    var forecast = LookupForecast(latitude, longitude);
                    callback.OnData(forecast);
          //      });
        }

        public ForecastDays LookupForecast(double latitude, double longitude)
        {
            var lanseria = latitude == -26 && longitude == 26;
            //var lanseria = latitude == -26 && longitude == 26;
            if (lanseria)
                return new ForecastDays
                    {
                        new ForecastDay
                            {
                                AveHumidity = 1,
                                Conditions = "",
                                Icon = "sunny",
                                Date = DateTime.Now,
                                High = 20,
                                Low = 10,
                                Period = 0,
                                ProbabilityOfPrecipitation = ""
                            }
                    };

            return null;
        }

        public OfficialStations LookupStations(double latitude, double longitude)
        {
            throw new NotImplementedException();
        }
    }
}