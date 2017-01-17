using System;
using Xamarin.Forms.Platform.Android;

namespace FBPlay.Droid
{
    public class AdvancedListViewRendererDroid : ListViewRenderer
    {
        void Control_ScrollStateChanged(object sender, Android.Widget.AbsListView.ScrollStateChangedEventArgs e)
        {

        }

        public AdvancedListViewRendererDroid()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ListView> e)
        {
            base.OnElementChanged(e);

            this.Control.ScrollStateChanged += Control_ScrollStateChanged;
        }
    }
}
