using System;
using MonoTouch.UIKit;
using System.Drawing;

namespace QuickWeather.iOS
{
    public class MyViewController : UIViewController
    {
        UIButton _button;
        int _numClicks;
        private const float ButtonWidth = 200;
        private const float ButtonHeight = 50;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.Frame = UIScreen.MainScreen.Bounds;
            View.BackgroundColor = UIColor.White;
            View.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;

            var rect = new RectangleF(0, 0, 100, 20);
            var label = new UILabel(rect)
                            {
                                Text = @"Well! Hellooo :-)",
                                Font = UIFont.BoldSystemFontOfSize(13),
                                BackgroundColor = UIColor.Clear
                            };

            View.Add(label);

            return;





            _button = UIButton.FromType(UIButtonType.RoundedRect);

            _button.Frame = new RectangleF(
                View.Frame.Width / 2 - ButtonWidth / 2,
                View.Frame.Height / 2 - ButtonHeight / 2,
                ButtonWidth,
                ButtonHeight);

            _button.SetTitle("Click me", UIControlState.Normal);

            _button.TouchUpInside += (sender, e) => _button.SetTitle(String.Format("clicked {0} times", _numClicks++), UIControlState.Normal);

            _button.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleTopMargin |
                UIViewAutoresizing.FlexibleBottomMargin;

            View.AddSubview(_button);
        }

    }
}

