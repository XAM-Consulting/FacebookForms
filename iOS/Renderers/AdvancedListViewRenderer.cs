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
            var advancedListView = this.Element as AdvancedListView;
            if (advancedListView != null && advancedListView.Scrolled != null)
            {
                advancedListView.Scrolled(new Xamarin.Forms.Point(Control.ContentOffset.X, Control.ContentOffset.Y));
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
        }

    }
}
