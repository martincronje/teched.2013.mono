using Android.App;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics;

namespace HelloWorld.Android
{
	[Activity (Label = "Hello World", MainLauncher = true)]
	public class Activity1 : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Main);

			var layout = (RelativeLayout)FindViewById(Resource.Id.layout);
		}
	}
}


