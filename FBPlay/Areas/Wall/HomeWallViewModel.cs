using System;
using System.Collections.Generic;

namespace FBPlay
{
    public class HomeWallViewModel
    {
        public List<IFeedItemViewModel> Items { get; set; }

        public HomeWallViewModel()
        {
            Items = FeedContentGenerator.Instance.GenerateFeedItem(100);
        }
    }
}
