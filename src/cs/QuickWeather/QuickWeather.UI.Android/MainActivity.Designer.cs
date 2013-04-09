using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace QuickWeather.UI
{
    public partial class MainActivity
    {
        public TextView Icon { get; private set; }
        public TextView TempLowLabel { get; private set; }
        public TextView TempHighLabel { get; private set; }
        public TextView MessageLabel { get; private set; }
        public TextView Button { get; private set; }

        private void InitializeComponent()
        {
            Button = FindViewById<Button>(Resource.Id.Button);
            Button.Typeface = Typeface.CreateFromAsset(this.Assets, "meteocons-webfont.ttf");

            Icon = FindViewById<TextView>(Resource.Id.Icon);
            Icon.Typeface = Typeface.CreateFromAsset(this.Assets, "meteocons-webfont.ttf");

            TempHighLabel = FindViewById<TextView>(Resource.Id.TextViewTempHigh);
            TempLowLabel = FindViewById<TextView>(Resource.Id.TextViewTempLow);
            MessageLabel = FindViewById<TextView>(Resource.Id.TextViewMessage);
        }
    }
}