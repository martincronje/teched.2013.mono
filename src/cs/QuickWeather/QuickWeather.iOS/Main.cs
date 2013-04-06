using MonoTouch.UIKit;
using QuickWeather.Core.Proxy;
using TinyIoC;

namespace QuickWeather.iOS
{
    public class Application
    {
        static void Main(string[] args)
        {
            TinyIoCContainer.Current.Register<IWeatherService>(new WeatherServiceStub());
            UIApplication.Main(args, null, "AppDelegate");
        }
    }
}