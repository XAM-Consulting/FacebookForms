using System;
using System.Diagnostics;
using FBPlay;
using FBPlay.iOS;
using UIKit;
using Xamarin.Forms.Platform.iOS;

[assembly: Xamarin.Forms.ExportRenderer(typeof(AdvancedListView), typeof(AdvancedListViewRenderer))]

namespace FBPlay.iOS
{
    public class AdvancedListViewRenderer : ListViewRenderer
    {
        void Control_Scrolled(object sender, EventArgs e)
        {
            var aLV = this.Element as AdvancedListView;
            if (aLV != null && aLV.Scrolled != null)
            {
                aLV.Scrolled(new Xamarin.Forms.Point(Control.ContentOffset.X, Control.ContentOffset.Y));
            }
        }

        public AdvancedListViewRenderer()
        {
            UIApplication.CheckForEventAndDelegateMismatches = false;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ListView> e)
        {
            base.OnElementChanged(e);

            this.Control.Scrolled += Control_Scrolled;

            if (e.OldElement != null)
            {
                ((AdvancedListView)e.OldElement).ScrollToPoint = null;
            }

            if (e.NewElement != null)
            {
                ((AdvancedListView)e.NewElement).ScrollToPoint = ScrollToPoint;
            }
        }

        void ScrollToPoint(Xamarin.Forms.Point obj)
        {
            this.Control.ContentOffset = new CoreGraphics.CGPoint(obj.X, obj.Y);
        }
    }
}
