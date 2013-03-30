//
//  NRAppDelegate.h
//  HelloWorld
//
//  Created by Martin Cronje on 2013/03/30.
//  Copyright (c) 2013 Martin Cronje. All rights reserved.
//

#import <UIKit/UIKit.h>

@class NRViewController;

@interface NRAppDelegate : UIResponder <UIApplicationDelegate>

@property (strong, nonatomic) UIWindow *window;

@property (strong, nonatomic) NRViewController *viewController;

@end
