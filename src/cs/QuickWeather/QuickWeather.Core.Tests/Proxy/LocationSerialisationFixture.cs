using NUnit.Framework;
using QuickWeather.Core.Proxy.Location;

namespace QuickWeather.Core.Tests.Proxy
{
    [TestFixture]
    public class LocationSerialisationFixture : SerialisationFixtureBase
    {
        [Test]
        public void ShouldDeserialiseValidTextForecastSucess ()
        {
            var response = DeserialiseFile<LocationResponse>("Resources/lookup.success.json");
            Assert.IsNotNull(response.Location);

            var location = response.Location;
            Assert.IsNotNull(location.City);
            Assert.IsNotNull(location.CountryName);
            Assert.IsNotNull(location.CountryIso3166);
            Assert.IsNotNull(location.State);
            Assert.IsNotNull(location.Type);
            Assert.IsNotNull(location.NearbyWeatherStations);

            Assert.Greater(location.NearbyWeatherStations.Airport.Station.Count, 0);
            Assert.Greater(location.NearbyWeatherStations.Pws.Station.Count, 0);

            foreach (var station in location.NearbyWeatherStations.Airport.Station)
            {
                Assert.IsNotNull(station.City);
                Assert.IsNotNull(station.Country);
                Assert.IsNotNull(station.State);
                Assert.IsNotNull(station.Lat);
                Assert.IsNotNull(station.Lon);
                Assert.IsNotNull(station.Icao);
            }

            foreach (var station in location.NearbyWeatherStations.Pws.Station)
            {
                Assert.IsNotNull(station.City);
                Assert.IsNotNull(station.Country);
                Assert.IsNotNull(station.State);
                Assert.IsNotNull(station.Lat);
                Assert.IsNotNull(station.Lon);
                Assert.IsNotNull(station.Id);
            }
        }
        
    }
}