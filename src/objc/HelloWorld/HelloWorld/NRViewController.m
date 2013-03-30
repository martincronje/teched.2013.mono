//
//  NRViewController.m
//  HelloWorld
//
//  Created by Martin Cronje on 2013/03/30.
//  Copyright (c) 2013 Martin Cronje. All rights reserved.
//

#import "NRViewController.h"

@interface NRViewController ()

@end

@implementation NRViewController

- (void)viewDidLoad
{
    [super viewDidLoad];
	// Do any additional setup after loading the view, typically from a nib.
    
    UILabel *label = [[UILabel alloc] initWithFrame:CGRectMake(0, 0, 100, 20)];
    
    label.backgroundColor = [UIColor clearColor];
    label.textColor = [UIColor redColor];
    
    label.text = @"Hello Teched";
    label.font = [UIFont systemFontOfSize:13.0f];
    
    [self.view addSubview:label];
}

- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

@end
