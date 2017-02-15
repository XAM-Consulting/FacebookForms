using System;
using Xamarin.Forms;

namespace FBPlay
{
    public class HomeWallListDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate WhatsOnYourMindTemplate { get; set; }
        public DataTemplate FeedItemTemplate { get; set; }
        public DataTemplate FeedItemNoImageTemplate { get; set; }
        public DataTemplate LottieTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is LottieAnimationViewModel)
                return LottieTemplate;
            if (item is WhatOnYourMindViewModel)
                return WhatsOnYourMindTemplate;
            var feedItem = item as FeedItemViewModel;
            if (string.IsNullOrEmpty(feedItem.ImageUrl))
                return FeedItemNoImageTemplate;
            return FeedItemTemplate;
        }
    }
}
