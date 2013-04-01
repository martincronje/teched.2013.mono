using System.Linq;
using NUnit.Framework;
using QuickWeather.Core.Proxy;

namespace QuickWeather.Core.IntegrationTests
{
    [TestFixture]
    public class WeatherUndergroundProxyFixture
    {
        [Test]
        public void ShouldReturnStationsCloseToLongLat()
        {
            var proxy = new WUndergroundProxy();
            var actual = proxy.LookupStations("-25.7940", "28.2034");

            Assert.IsNotNull(actual);
            Assert.Greater(actual.NearbyWeatherStations.Airport.Station.Count, 0);
        }

        [Test]
        public void ShouldReturnWeatherForecastForLatLong()
        {
            var proxy = new WUndergroundProxy();
            var actual = proxy.LookupForecast("-25.7940", "28.2034");

            Assert.IsNotNull(actual);
            Assert.Greater(actual.SimpleForecast.ForecastDay.Count, 0);
        }

        [Test]
        public void ShouldReturnWeatherForecastForLatLong_AsRetrunedFromGeoLookup()
        {
            var proxy = new WUndergroundProxy();

            var stations = proxy.LookupStations("-25.7940", "28.2034");
            var station = stations.NearbyWeatherStations.Airport.Station.First();
            var actual = proxy.LookupForecast(station.Lat, station.Lon);

            Assert.IsNotNull(actual);
            Assert.Greater(actual.SimpleForecast.ForecastDay.Count, 0);
        }
    }
}
