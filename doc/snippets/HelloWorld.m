UILabel *label = [[UILabel alloc] initWithFrame:CGRectMake(0, 0, 100, 20)];

label.backgroundColor = [UIColor clearColor];
label.font = [UIFont systemFontOfSize:13.0f];
label.textColor = [UIColor redColor];
label.text = @"Hello Teched";

[self.view addSubview:label];
