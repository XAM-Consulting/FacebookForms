using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FBPlay
{
    public class HomeWallViewModel
    {
        public List<IFeedItemViewModel> Items { get; set; }

        public HomeWallViewModel(ContentPage page)
        {
			Items = new FeedContentGenerator(page.Navigation).GenerateFeedItem(5000);
        }
    }
}
