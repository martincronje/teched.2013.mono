using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using MonoTouch.UIKit;

namespace QuickWeather.iOS
{
    public partial class MainViewController
    {
        private void InitializeComponent()
        {
            SetupView();
            SetupButton();
            SetupIcon();
            SetupLabels();
            SetupStation();
        }

        private void SetupLabels()
        {
            TempLowLabel = new UILabel
            {
                TextColor = UIColor.White,
                BackgroundColor = UIColor.Clear,
                Text = "low: 0°",
                Font = UIFont.FromName("Euphemia UCAS", 16.0f),
                Frame = new RectangleF(10, 30, (View.Frame.Width / 2) - 10, 30),
                AutoresizingMask = UIViewAutoresizing.FlexibleRightMargin | UIViewAutoresizing.FlexibleWidth,
                TextAlignment = UITextAlignment.Left,
                AdjustsFontSizeToFitWidth = false

            };
            View.AddSubview(TempLowLabel);


            TempHighLabel = new UILabel
            {
                TextColor = UIColor.White,
                BackgroundColor = UIColor.Clear,
                Text = "high: 0°",
                Font = UIFont.FromName("Euphemia UCAS", 16.0f),
                Frame = new RectangleF((View.Frame.Width / 2), 30, (View.Frame.Width / 2) - 10, 30),
                AutoresizingMask = UIViewAutoresizing.FlexibleLeftMargin | UIViewAutoresizing.FlexibleWidth,
                TextAlignment = UITextAlignment.Right,
                AdjustsFontSizeToFitWidth = false

            };
            View.AddSubview(TempHighLabel);
        }

        private void SetupStation()
        {
            MessageLabel = new UILabel(new RectangleF(0, 30, 300, 30))
            {
                Frame = new RectangleF(0, 0, View.Frame.Width, 30),
                TextColor = UIColor.White,
                Text = "tap compass to lookup",
                BackgroundColor = UIColor.FromRGBA(0, 0, 0, 75),
                Font = UIFont.FromName("Euphemia UCAS", 20),
                TextAlignment = UITextAlignment.Center
            };
            View.AddSubview(MessageLabel);
        }

        private void SetupIcon()
        {
            var frame = new RectangleF(10, ((View.Frame.Height - View.Frame.Width) / 2) - 30, View.Frame.Width - 20, View.Frame.Width);
            Icon = new UILabel
            {
                Frame = frame,
                TextColor = UIColor.White,
                BackgroundColor = UIColor.Clear,
                Font = UIFont.FromName("Meteocons", 320.0f),
                Text = ")",
                AdjustsFontSizeToFitWidth = true
            };

            Button.AutoresizingMask = UIViewAutoresizing.FlexibleTopMargin | UIViewAutoresizing.FlexibleBottomMargin;

            View.AddSubview(Icon);
        }

        private void SetupButton()
        {
            Button = new UIButton(UIButtonType.Custom);

            var frame = new RectangleF(0, View.Frame.Height - 60, View.Frame.Width, 60);
            Button.Frame = frame;

            Button.AutoresizingMask = UIViewAutoresizing.FlexibleTopMargin | UIViewAutoresizing.FlexibleWidth;
            Button.TouchDown += (sender, args) =>
            {
                Button.BackgroundColor = UIColor.FromRGBA(0, 0, 0, 75);
            };
            Button.TouchCancel += (sender, args) =>
            {
                Button.BackgroundColor = UIColor.FromRGBA(0, 0, 0, 170);
            };
            Button.TouchUpInside += (sender, args) =>
            {
                Button.BackgroundColor = UIColor.FromRGBA(0, 0, 0, 170);
            };
            Button.SetTitleColor(UIColor.White, UIControlState.Normal);
            Button.SetTitle("(", UIControlState.Normal);
            Button.BackgroundColor = UIColor.FromRGBA(0, 0, 0, 170);
            Button.Font = UIFont.FromName("Meteocons", 30.0f);

            View.AddSubview(Button);
        }

        private void SetupView()
        {
            View.Frame = UIScreen.MainScreen.Bounds;
            View.BackgroundColor = UIColor.FromRGB(0, 149, 137);

            View.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
        }

    }
}
