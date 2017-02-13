using System;
using Xamarin.Forms;

namespace FBPlay
{
    public class HomeWallListDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate WhatsOnYourMindTemplate { get; set; }
        public DataTemplate FeedItemTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return item is WhatOnYourMindViewModel ? WhatsOnYourMindTemplate : FeedItemTemplate;
        }
    }
}
