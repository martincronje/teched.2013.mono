using System.IO;
using System.Runtime.Serialization.Json;
using NUnit.Framework;

namespace QuickWeather.Proxy.Tests
{
    public class SerialisationFixtureBase
    {
        protected static T DeserialiseFile<T>(string path)
        {
            var serialiser = new DataContractJsonSerializer(typeof(T));
            var input = File.OpenRead(path);
            var deserialised = serialiser.ReadObject(input);

            Assert.IsNotNull(deserialised);
            Assert.IsInstanceOf<T>(deserialised);

            return (T)deserialised;
        }
    }
}