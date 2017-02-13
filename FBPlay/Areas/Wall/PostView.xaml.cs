using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FBPlay
{
    public partial class PostView : InstrumentedGrid
    {
        public PostView()
        {
            InitializeComponent();
            //https://tctechcrunch2011.files.wordpress.com/2016/02/facebook-reactions-animation.gif?w=1348&h=388
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
				ImageUrl.Source = feedItemViewModel.ImageUrl;
				LikeCount.Text = feedItemViewModel.LikeCount + " Likes";
				CommentCount.Text = feedItemViewModel.LikeCount + " Comments";
			}
		}

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            if (likeArea.TranslationY == -35)
            {
                await likeArea.TranslateTo(0, 0, 100, Easing.Linear);
                await Task.Delay(50);
                await likeArea.FadeTo(0, 50);
            }
            else
            {
                await likeArea.FadeTo(1d, 20);
                await likeArea.TranslateTo(0, -35, 100, Easing.Linear);
            }
        }
    }
}
