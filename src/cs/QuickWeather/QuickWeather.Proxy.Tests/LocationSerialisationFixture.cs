using NUnit.Framework;
using QuickWeather.Proxy.Forecast;
using QuickWeather.Proxy.Location;

namespace QuickWeather.Proxy.Tests
{
    [TestFixture]
    public class LocationSerialisationFixture : SerialisationFixtureBase
    {
        [Test]
        public void ShouldDeserialiseValidTextForecastSucess ()
        {
            var forecastResponse = DeserialiseFile<LocationResponse>("Resources/lookup.success.json");
            Assert.IsNotNull(forecastResponse.Location);

            var location = forecastResponse.Location;
            Assert.IsNotNull(location.City);
            Assert.IsNotNull(location.Country);
            Assert.IsNotNull(location.State);
            Assert.IsNotNull(location.Type);
            Assert.IsNotNull(location.WeatherStations);

            foreach (var station in location.WeatherStations.Official)
            {
                Assert.IsNotNull(station.City);
                Assert.IsNotNull(station.Country);
                Assert.IsNotNull(station.State);
                Assert.IsNotNull(station.Latitude);
                Assert.IsNotNull(station.Longtitude);
                Assert.IsNotNull(station.Icao);
            }

            foreach (var station in location.WeatherStations.Unofficial)
            {
                Assert.IsNotNull(station.City);
                Assert.IsNotNull(station.Country);
                Assert.IsNotNull(station.State);
                Assert.IsNotNull(station.Latitude);
                Assert.IsNotNull(station.Longtitude);
                Assert.IsNotNull(station.Id);
                Assert.IsNotNull(station.Neighborhood);
            }


        }
        
    }
}