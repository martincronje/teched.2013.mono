using System.Linq;
using NUnit.Framework;
using QuickWeather.Core.Proxy;

namespace QuickWeather.Core.IntegrationTests
{
    [TestFixture]
    public class WUndergroundProxyFixture
    {
        [Test]
        public void ShouldReturnStationsCloseToLongLat()
        {
            var proxy = new WUndergroundProxy();
            var actual = proxy.LookupStations(-25.7940, 28.2034);

            Assert.IsNotNull(actual);
            Assert.Greater(actual.Count, 0);
        }

        [Test]
        public void ShouldReturnWeatherForecastForLatLong()
        {
            var proxy = new WUndergroundProxy();
            var actual = proxy.LookupForecast(-25.7940, 28.2034);

            Assert.IsNotNull(actual);
            Assert.Greater(actual.Count, 0);
        }

        [Test]
        public void ShouldReturnWeatherForecastForLatLong_AsRetrunedFromGeoLookup()
        {
            var proxy = new WUndergroundProxy();

            var stations = proxy.LookupStations(-25.7940, 28.2034);
            var station = stations.First();
            var actual = proxy.LookupForecast(station.Location.Latitude, station.Location.Longitude);

            Assert.IsNotNull(actual);
            Assert.Greater(actual.Count, 0);
        }
    }
}
