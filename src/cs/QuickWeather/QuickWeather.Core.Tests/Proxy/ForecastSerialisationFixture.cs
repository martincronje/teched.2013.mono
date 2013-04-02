using NUnit.Framework;
using QuickWeather.Core.Proxy.Forecast;

namespace QuickWeather.Core.Tests.Proxy
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

            var textForecast = forecastResponse.Forecast.TxtForecast;
            Assert.IsNotNull(textForecast);
            Assert.IsNotNull(textForecast.ForecastDay);

            Assert.AreEqual(8, textForecast.ForecastDay.Count);
            Assert.AreEqual("2:00 PM PDT", textForecast.Date);

            foreach (var day in textForecast.ForecastDay)
            {
                Assert.AreNotEqual(0, day.Title.Length);
                Assert.AreNotEqual(0, day.FcttextMetric.Length);
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
            Assert.IsNotNull(simpleForecast.ForecastDay);

            Assert.AreEqual(4, simpleForecast.ForecastDay.Count);

            foreach (var day in simpleForecast.ForecastDay)
            {
                Assert.IsNotNull(day.High);
                Assert.IsNotNull(day.Low);

                Assert.IsNotNull(day.QpfAllday);
                Assert.IsNotNull(day.QpfDay);
                Assert.IsNotNull(day.QpfNight);

                Assert.IsNotNull(day.SnowAllday);
                Assert.IsNotNull(day.SnowDay);
                Assert.IsNotNull(day.SnowNight);

                Assert.AreNotEqual(0, day.Icon);
                Assert.AreNotEqual(0, day.Conditions);
                Assert.AreNotEqual(0, day.ProbabilityOfPrecipitation);

                Assert.AreNotEqual(0, day.AveHumidity);
                Assert.AreNotEqual(0, day.MinHumidity);
                Assert.AreNotEqual(0, day.MaxHumidity);
            }
        }
    }
}