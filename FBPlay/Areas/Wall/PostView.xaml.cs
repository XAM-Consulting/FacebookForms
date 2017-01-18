using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FFImageLoading.Forms;
using Xamarin.Forms;

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

            var viewModel = this.BindingContext as FeedItemViewModel;
            if (viewModel != null && LikeLayout.Children.Count == 0)
            {
                foreach (string imagesource in viewModel.EmojiTypes)
                {
                    var image = new CachedImage
                    {
                        HeightRequest = 20,
                        WidthRequest = 20,
                        Source = imagesource
                    };
                    LikeLayout.Children.Add(image);
                }
                var label = new Label { Text = $"{viewModel.LikeCount} Likes" };
                LikeLayout.Children.Add(label);
            }
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            if (likeArea.TranslationY == -35)
            {
                await likeArea.TranslateTo(0, 0, 100, Easing.BounceIn);
                await Task.Delay(50);
                await likeArea.FadeTo(0, 50);
            }
            else
            {
                await likeArea.FadeTo(1d, 20);
                await likeArea.TranslateTo(0, -35, 100, Easing.BounceOut);
            }
        }
    }
}
