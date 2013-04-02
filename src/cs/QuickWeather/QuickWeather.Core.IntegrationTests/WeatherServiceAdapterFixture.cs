using System.Linq;
using NUnit.Framework;
using QuickWeather.Core.Model;

namespace QuickWeather.Core.IntegrationTests
{
    [TestFixture]
   public class WeatherServiceAdapterFixture
    {
        [Test]
        public void ShouldReturnStationsCloseToCoordinates()
        {
            var adapter = new WeatherService();
            var geoLocation = new GeoLocation(-25.7940, 28.2034);

            var stations = adapter.QueryClosestStations(geoLocation);

            Assert.IsNotNull(stations);
            Assert.Greater(stations.Count, 0);
        }

        [Test]
        public void ShouldReturnWeatherForecastForCoordinates()
        {
            var adapter = new WeatherService();
            var geoLocation = new GeoLocation(-25.7940, 28.2034);
            var forecast = adapter.QueryForecast(geoLocation);

            Assert.IsNotNull(forecast);
            Assert.Greater(forecast.Count, 0);
        }

        [Test]
        public void ShouldReturnWeatherForecastForCoordinates_AsRetrunedFromGeoLookup()
        {
            var adapter = new WeatherService();
            var geoLocation = new GeoLocation(-25.7940, 28.2034);
            var stations = adapter.QueryClosestStations(geoLocation);
            var forecast = adapter.QueryForecast(stations.First().Location);

            Assert.IsNotNull(forecast);
            Assert.Greater(forecast.Count, 0);
        }
    }
}
