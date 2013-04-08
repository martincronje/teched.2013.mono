TextView textView = new TextView(this);

textView.setText("Hello TechEd 2013!");
textView.setTextColor(Color.RED);

LayoutParams layoutParams = new LayoutParams(LayoutParams.WRAP_CONTENT, 
					     LayoutParams.WRAP_CONTENT);

layoutParams.height = 30;
layoutParams.width = 200;

textView.setLayoutParams(layoutParams);
layout.addView(textView);
