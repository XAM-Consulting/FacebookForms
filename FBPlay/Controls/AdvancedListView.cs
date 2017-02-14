using System;
using Xamarin.Forms;

namespace FBPlay
{
    public class AdvancedListView : ListView
    {
        public Action<Point> Scrolled { get; set; }

        public AdvancedListView() : base(ListViewCachingStrategy.RecycleElement)
        {
        }
    }
}
