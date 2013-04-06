using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace QuickWeather.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate
    {
        UIWindow _window;
        MainViewController _viewViewController;

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            _window = new UIWindow(UIScreen.MainScreen.Bounds);

            _viewViewController = new MainViewController();
            _window.RootViewController = _viewViewController;

            _window.MakeKeyAndVisible();

            return true;
        }
    }
}

