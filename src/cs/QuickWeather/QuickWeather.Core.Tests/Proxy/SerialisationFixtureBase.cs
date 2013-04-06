using System.IO;
using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;

namespace QuickWeather.Core.Tests.Proxy
{
    public class SerialisationFixtureBase
    {
        protected static T DeserialiseFile<T>(string path)
        {
            var deserialiser = new JsonDeserializer();
            var restResponse = new RestResponse();
            restResponse.Content = File.ReadAllText(path);
            restResponse.ContentLength = restResponse.Content.Length;

            var deserialised = deserialiser.Deserialize<T>(restResponse);

            Assert.IsNotNull(deserialised);
            Assert.IsInstanceOf<T>(deserialised);

            return (T)deserialised;
        }
    }
}