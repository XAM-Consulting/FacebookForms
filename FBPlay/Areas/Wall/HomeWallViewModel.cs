using System;
using System.Collections.Generic;

namespace FBPlay
{
    public class HomeWallViewModel
    {
        public List<FeedItemViewModel> Items { get; set; }

        public HomeWallViewModel()
        {
            Items = FeedContentGenerator.Instance.GenerateFeedItem(100);
        }
    }
}
