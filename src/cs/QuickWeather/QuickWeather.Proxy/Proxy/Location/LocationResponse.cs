using System.Runtime.Serialization;

namespace QuickWeather.Proxy.Location
{
    [DataContract]
    public class LocationResponse
    {
        [DataMember(Name = "location")]
        public Location Location { get; set; }
    }
}