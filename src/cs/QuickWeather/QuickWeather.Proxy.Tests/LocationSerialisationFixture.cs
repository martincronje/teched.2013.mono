using System.IO;
using System.Runtime.Serialization.Json;
using NUnit.Framework;
using QuickWeather.Proxy.Forecast;

namespace QuickWeather.Proxy.Tests
{
    [TestFixture]
    public class LocationSerialisationFixture
    {
        [Test]
        public void ShouldDeserialiseValidTextForecastSucess ()
        {
            var forecastResponse = DeserialiseFile();

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
            var forecastResponse = DeserialiseFile();
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

        private static ForecastResponse DeserialiseFile()
        {
            var serialiser = new DataContractJsonSerializer(typeof(ForecastResponse));
            var input = File.OpenRead("Resources/forecast.success.json");
            var deserialised = serialiser.ReadObject(input);

            Assert.IsNotNull(deserialised);
            Assert.IsInstanceOf<ForecastResponse>(deserialised);

            var forecastResponse = (ForecastResponse)deserialised;

            Assert.IsNotNull(forecastResponse.Forecast);
            Assert.IsNotNull(forecastResponse.Forecast.SimpleForecast);

            return forecastResponse;

        }

    }
}