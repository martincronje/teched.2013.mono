using System;

using Android.App;
using Android.Content;
using Android.Runtime;
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

			RelativeLayout layout = (RelativeLayout)FindViewById(Resource.Id.layout);

			ViewGroup.LayoutParams layoutParams = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);

			layoutParams.Width = 300;
			layoutParams.Height = 30;

			TextView textView = new TextView(this);

			textView.Text = "Hello TechEd 2013";

			textView.SetTextColor(Color.Red);
			textView.LayoutParameters = layoutParams;

			layout.AddView(textView);
		}
	}
}


