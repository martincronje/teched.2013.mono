using System;
using System.Threading;
using QuickWeather.Core.Model;

namespace QuickWeather.Core.Services
{
    public class WeatherServiceStub : IWeatherService
    {
        public void LookupStationsAsync(double latitude, double longitude, ServiceCallback<OfficialStations> callback)
        {
            ThreadPool.QueueUserWorkItem((c =>
                {
                    var stations = LookupStations(latitude, longitude);
                    callback.OnData(stations);
                }));
        }


        public OfficialStations LookupStations(double latitude, double longitude)
        {
            Thread.Sleep(2000);

            if (IsLanseria(latitude, longitude))
                return LookupStationLanseria(latitude, longitude);

            if (IsDubai(latitude, longitude))
                return LookupStationDubai(latitude, longitude);

            if (IsKiev(latitude, longitude))
                return LookupStationKiev(latitude, longitude);

            return null;
        }

        public void LookupForecastAsync(double latitude, double longitude, ServiceCallback<ForecastDays> callback)
        {
            ThreadPool.QueueUserWorkItem(c =>
                {
                    var forecast = LookupForecast(latitude, longitude);
                    callback.OnData(forecast);
                });
        }

        public ForecastDays LookupForecast(double latitude, double longitude)
        {
            Thread.Sleep(2000);
            if (IsLanseria(latitude, longitude))
                return LookupForecastLanseria();

            if (IsDubai(latitude, longitude))
                return LookupForecastDubai();

            if (IsKiev(latitude, longitude))
                return LookupForecastKiev();

            return null;
        }


        private static bool IsDubai(double latitude, double longitude)
        {
            return DoubleInRange(latitude, 22, 28) && DoubleInRange(longitude, 52, 58);
        }
        private static bool IsKiev(double latitude, double longitude)
        {
            return DoubleInRange(latitude, 47, 53) && DoubleInRange(longitude, 28, 34);
        }
        private static bool IsLanseria(double latitude, double longitude)
        {
            return DoubleInRange(latitude, -29, -23) && DoubleInRange(longitude, 25, 31);
        }

        private static bool DoubleInRange(double left, double right, double right2)
        {
            return left > right && left < right2;
        }

        private OfficialStations LookupStationKiev(double latitude, double longitude)
        {
            return new OfficialStations
                {
                    new OfficialStation
                        {
                            City = "Kyiv city",
                            Country = "Ukraine",
                            Location = new GeoLocation(latitude, longitude)

                        }
                };
        }

        private OfficialStations LookupStationDubai(double latitude, double longitude)
        {
            return new OfficialStations
                {
                    new OfficialStation
                        {
                            City = "Dubai",
                            Country = "United Arab Emirates",
                            Location = new GeoLocation(latitude, longitude)

                        }
                };
        }

        private OfficialStations LookupStationLanseria(double latitude, double longitude)
        {
            return new OfficialStations
                {
                    new OfficialStation
                        {
                            City = "Lanseria Airport",
                            Country = "South Africa",
                            Location = new GeoLocation(latitude, longitude)

                        }
                };
        }


        private static ForecastDays LookupForecastDubai()
        {
            return new ForecastDays
                {
                    new ForecastDay
                        {
                            AveHumidity = 1,
                            Conditions = "",
                            Icon = "hazy",
                            Date = DateTime.Now,
                            High = 33,
                            Low = 23,
                            Period = 0,
                            ProbabilityOfPrecipitation = ""
                        }
                };
        }

        private static ForecastDays LookupForecastKiev()
        {
            return new ForecastDays
                {
                    new ForecastDay
                        {
                            AveHumidity = 1,
                            Conditions = "",
                            Icon = "sunny",
                            Date = DateTime.Now,
                            High =11,
                            Low =2,
                            Period = 0,
                            ProbabilityOfPrecipitation = ""
                        }
                };
        }

        private static ForecastDays LookupForecastLanseria()
        {
            return new ForecastDays
                {
                    new ForecastDay
                        {
                            AveHumidity = 1,
                            Conditions = "",
                            Icon = "partlycloudy",
                            Date = DateTime.Now,
                            High = 22,
                            Low = 11,
                            Period = 0,
                            ProbabilityOfPrecipitation = ""
                        }
                };
        }

    }
}