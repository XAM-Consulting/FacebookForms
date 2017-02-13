using System;
using System.Globalization;
using AppKit;
using CoreGraphics;
using Foundation;
using Xamarin.Forms;
using Xamarin.Forms.Platform.MacOS;

namespace FBPlay.Mac
{
    [Register("AppDelegate")]
    public class AppDelegate : FormsApplicationDelegate
    {
        NSWindow _window;
        public AppDelegate()
        {
            ObjCRuntime.Runtime.MarshalManagedException += (sender, args) =>
            {
                Console.WriteLine(args.Exception.ToString());
            };

            var style = NSWindowStyle.Closable | NSWindowStyle.Resizable | NSWindowStyle.Titled;

            var rect = new CoreGraphics.CGRect(200, 1000, 400, 768);
            //var rect = NSWindow.FrameRectFor(NSScreen.MainScreen.Frame, style);
            _window = new NSWindow(rect, style, NSBackingStore.Buffered, false);
            _window.Title = "FBPlay";
            _window.TitleVisibility = NSWindowTitleVisibility.Hidden;
        }

        public override NSWindow MainWindow
        {
            get { return _window; }
        }


        public override void DidFinishLaunching(NSNotification notification)
        {
            // Insert code here to initialize your application
            Forms.Init();

            var app = new FBPlay.App();
            LoadApplication(app);
            base.DidFinishLaunching(notification);
        }

    }
}
