namespace QuickWeather.Core.Services.Location
{
    public class UnofficialWeatherStation
    {
        public string Neighborhood { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Id { get; set; }
        public decimal Lat { get; set; }
        public decimal Lon { get; set; }
        public int DistanceKm { get; set; }
    }
}