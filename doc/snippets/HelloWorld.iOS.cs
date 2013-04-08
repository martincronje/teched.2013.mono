var rect = new RectangleF (0, 0, 200, 20);

var label = new UILabel (rect)
    {
	TextColor = UIColor.Red,
	BackgroundColor = UIColor.Clear,
	Text = "Hello TechEd 2013",
	Font = UIFont.SystemFontOfSize(13.0f)
    };

View.AddSubview (label);
