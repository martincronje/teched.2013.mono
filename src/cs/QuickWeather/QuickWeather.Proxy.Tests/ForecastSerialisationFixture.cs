using NUnit.Framework;
using QuickWeather.Proxy.Forecast;

namespace QuickWeather.Proxy.Tests
{
    [TestFixture]
    public class ForecastSerialisationFixture : SerialisationFixtureBase
    {
        [Test]
        public void ShouldDeserialiseValidTextForecastSucess()
        {
            var forecastResponse = DeserialiseFile<ForecastResponse>("Resources/forecast.success.json");
            Assert.IsNotNull(forecastResponse.Forecast);
            Assert.IsNotNull(forecastResponse.Forecast.SimpleForecast);

            var textForecast = forecastResponse.Forecast.TextForecast;
            Assert.IsNotNull(textForecast);
            Assert.IsNotNull(textForecast.Days);

            Assert.AreEqual(8, textForecast.Days.Count);
            Assert.AreEqual("2:00 PM PDT", textForecast.DateRaw);


            foreach (var day in textForecast.Days)
            {
                Assert.AreNotEqual(0, day.Title.Length);
                Assert.AreNotEqual(0, day.Text.Length);
                Assert.AreNotEqual(0, day.Icon.Length);
            }
        }

        [Test]
        public void ShouldDeserialiseValidSimpleForecastSucess()
        {
            var forecastResponse = DeserialiseFile<ForecastResponse>("Resources/forecast.success.json");
            Assert.IsNotNull(forecastResponse.Forecast);
            Assert.IsNotNull(forecastResponse.Forecast.SimpleForecast);

            var simpleForecast = forecastResponse.Forecast.SimpleForecast;

            Assert.IsNotNull(simpleForecast);
            Assert.IsNotNull(simpleForecast.Days);

            Assert.AreEqual(4, simpleForecast.Days.Count);

            foreach (var day in simpleForecast.Days)
            {
                Assert.IsNotNull(day.High);
                Assert.IsNotNull(day.Low);

                Assert.IsNotNull(day.QpfAllDay);
                Assert.IsNotNull(day.QpfDay);
                Assert.IsNotNull(day.QpfNight);

                Assert.IsNotNull(day.SnowAllDay);
                Assert.IsNotNull(day.SnowDay);
                Assert.IsNotNull(day.SnowNight);

                Assert.AreNotEqual(0, day.Icon);
                Assert.AreNotEqual(0, day.Conditions);
                Assert.AreNotEqual(0, day.ProbabilityOfPrecipitation);

                Assert.AreNotEqual(0, day.AverageHumidity);
                Assert.AreNotEqual(0, day.MinHumidity);
                Assert.AreNotEqual(0, day.MaxHumidity);
            }
        }
    }
}