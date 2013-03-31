using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace HelloWorld.iOS
{
	public partial class HelloWorld_iOSViewController : UIViewController
	{
		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public HelloWorld_iOSViewController ()
			: base (UserInterfaceIdiomIsPhone ? "HelloWorld_iOSViewController_iPhone" : "HelloWorld_iOSViewController_iPad", null)
		{
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			RectangleF rect = new RectangleF (0, 0, 200, 20);
			UILabel label = new UILabel (rect);

			label.TextColor = UIColor.Red;
			label.BackgroundColor = UIColor.Clear;

			label.Text = "Hello TechEd 2013";
			label.Font = UIFont.SystemFontOfSize (13.0f);

			this.View.AddSubview (label);

			// Perform any additional setup after loading the view, typically from a nib.
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			if (UserInterfaceIdiomIsPhone) {
				return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
			} else {
				return true;
			}
		}
	}
}

