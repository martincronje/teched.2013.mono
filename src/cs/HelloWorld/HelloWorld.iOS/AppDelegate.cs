using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace HelloWorld.iOS
{
	[Register ("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate
	{
		UIWindow _window;
		HelloWorldViewController _viewController;

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			_window = new UIWindow (UIScreen.MainScreen.Bounds);
			
			_viewController = new HelloWorldViewController ();
			_window.RootViewController = _viewController;
			_window.MakeKeyAndVisible ();
			
			return true;
		}
	}
}

