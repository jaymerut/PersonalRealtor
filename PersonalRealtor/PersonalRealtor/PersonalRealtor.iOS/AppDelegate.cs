﻿using System;
using System.Collections.Generic;
using System.Linq;
using Com.OneSignal;
using Com.OneSignal.Abstractions;
using Foundation;
using Plugin.Segmented.Control.iOS;
using UIKit;

namespace PersonalRealtor.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Firebase.Core.App.Configure();

            global::Xamarin.Forms.Forms.Init();
            SegmentedControlRenderer.Initialize();
            LoadApplication(new App());

            // Remove this method to stop OneSignal Debugging  
            OneSignal.Current.SetLogLevel(LOG_LEVEL.VERBOSE, LOG_LEVEL.NONE);

            OneSignal.Current.StartInit("1c757b00-e5c4-4309-954c-e02d24304b80")
            .Settings(new Dictionary<string, bool>() {
                { IOSSettings.kOSSettingsKeyInAppLaunchURL, false } })
            .InFocusDisplaying(OSInFocusDisplayOption.Notification)
            .EndInit();

            return base.FinishedLaunching(app, options);
        }
    }
}
