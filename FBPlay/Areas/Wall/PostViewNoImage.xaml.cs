using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FBPlay
{
    public partial class PostViewNoImage : InstrumentedGrid
    {
        public PostViewNoImage()
        {
            InitializeComponent();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            var feedItemViewModel = BindingContext as FeedItemViewModel;

            if (feedItemViewModel != null)
            {
                AuthorPhoto.Source = feedItemViewModel.AuthorPhoto;
                AuthorName.Text = feedItemViewModel.AuthorName;
                Date.Text = feedItemViewModel.Date.ToString();
                Content.Text = feedItemViewModel.Content;
                LikeCount.Text = feedItemViewModel.LikeCount + " Likes";
                CommentCount.Text = feedItemViewModel.LikeCount + " Comments";
            }
        }
    }
}
