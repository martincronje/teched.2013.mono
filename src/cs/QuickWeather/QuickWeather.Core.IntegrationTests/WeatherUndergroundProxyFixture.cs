using NUnit.Framework;

namespace QuickWeather.Core.IntegrationTests
{
    [TestFixture]
    public class WeatherUndergroundProxyFixture
    {
        [Test]
        public void ShouldReturnStationsCloseToLongLat()
        {
            var proxy = new WeatherUndergroundProxy();

            var actual = proxy.LookupStations( "37.776289", "-122.395234");

            Assert.IsNotNull(actual);
            Assert.Greater(actual.NearbyWeatherStations.Airport.Station.Count, 0);

            //http://api.wunderground.com/api/1ee1456e1469d243/geolookup/q/37.776289,-122.395234.json
        }
    }
}
