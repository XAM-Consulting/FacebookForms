using System;
using System.Collections.Generic;
using System.Linq;
using FFImageLoading.Forms.Touch;
using Foundation;
using UIKit;

namespace FBPlay.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            new Airbnb.Lottie.LAAnimationView();
            new Lottie.Forms.AnimationView();                  
            new FreshEssentials.iOS.AdvancedFrameRendereriOS();

            CachedImageRenderer.Init();

            LoadApplication(new App());

            UIApplication.SharedApplication.StatusBarHidden = false;
            UIApplication.SharedApplication.StatusBarStyle = UIStatusBarStyle.BlackTranslucent;

            return base.FinishedLaunching(app, options);
        }
    }
}
