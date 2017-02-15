using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FBPlay
{
    public class FeedContentGenerator
    {
        List<Func<IFeedItemViewModel>> _generators = new List<Func<IFeedItemViewModel>>();
        Random _random = new Random();
		INavigation _navigation;

        public FeedContentGenerator(INavigation navigation)
        {
			_navigation = navigation;
            _generators.Add(Beach1);
            _generators.Add(Beach2);
            _generators.Add(Beach3);
            _generators.Add(Kid);
			_generators.Add(Yoga);
            _generators.Add(PanDemo);
            _generators.Add(AnimationDemo);
            _generators.Add(LottieDemo);
        }

		Command GetCommand()
		{
			return new Command(() =>
			{
                _navigation.PushAsync(new PinchDemoPage());
			});
		}

		Command PanSampleCommand()
		{
			return new Command(() =>
			{
				_navigation.PushAsync(new PanDemoPage());
			});
		}

        Command AnimationSampleCommand()
        {
            return new Command(() =>
            {
                _navigation.PushModalAsync(new AnimationPostPage());
            });
        }

        public List<IFeedItemViewModel> GenerateFeedItem(int count)
        {
            var items = new List<IFeedItemViewModel>();
            items.Add(new WhatOnYourMindViewModel(_navigation) { AuthorPhoto = "michael.jpg" });

            for (int i = 1; i < count; i++)
            {
				var idx = (int)(_random.NextDouble() * 100) % _generators.Count;
				System.Diagnostics.Debug.WriteLine(idx);
                items.Add(_generators[idx]());
            }
            return items;
        }

        FeedItemViewModel Beach1()
        {
			return new FeedItemViewModel(GetCommand())
            {
                AuthorPhoto = "michael.jpg",
                Date = DateTime.Now,
                AuthorName = "Peter Green",

                Content = "Life's a beach",
                ImageUrl = "beach1.jpeg",

                LikeCount = 2,
                EmojiTypes = new List<string> { "Cool.png", "LOL.png" },
                CommentCount = 5
            };
        }

        IFeedItemViewModel LottieDemo()
        {
            return new LottieAnimationViewModel();
        }

		FeedItemViewModel PanDemo()
		{
			return new FeedItemViewModel(PanSampleCommand())
			{
				AuthorPhoto = "michael.jpg",
				Date = DateTime.Now,
				AuthorName = "Peter Green",

				Content = "This is a pan demo!",
				ImageUrl = "MonoMonkey.jpg",

				LikeCount = 2,
				CommentCount = 5
			};
		}

        FeedItemViewModel AnimationDemo()
        {
            return new FeedItemViewModel(AnimationSampleCommand())
            {
                AuthorPhoto = "michael.jpg",
                Date = DateTime.Now,
                AuthorName = "Mr Animation",

                Content = "This is a Animation demo!",

                LikeCount = 2,
                CommentCount = 5
            };
        }

		FeedItemViewModel Beach2()
        {
			return new FeedItemViewModel(GetCommand())
            {
                AuthorPhoto = "michael.jpg",
                Date = DateTime.Now,
                AuthorName = "Michael Ridland",

                Content = "This is where I write something great about my holiday!",
                ImageUrl = "beach2.jpg",

                LikeCount = 4,
                EmojiTypes = new List<string> { "Cool.png", "LOL.png", "Wink.png" },
                CommentCount = 9
            };
        }

        FeedItemViewModel Beach3()
        {
			return new FeedItemViewModel(GetCommand())
            {
                AuthorPhoto = "Jesse.png",
                Date = DateTime.Now,
                AuthorName = "Jesse Jiang",

                Content = "Seriously how many holidays can you go on",
                ImageUrl = "beach3.jpeg",

                LikeCount = 1,
                EmojiTypes = new List<string> { "Cool.png" },
                CommentCount = 3
            };
        }

        FeedItemViewModel Kid()
        {
			return new FeedItemViewModel(GetCommand())
            {
                AuthorPhoto = "michael.jpg",
                Date = DateTime.Now,
                AuthorName = "John McDonald",

                Content = "Why do people always have to upload pictures of there kids!",
                ImageUrl = "kid1.jpg",

                LikeCount = 1,
                EmojiTypes = new List<string> { "LOL.png" },
                CommentCount = 3
            };
        }

        FeedItemViewModel Yoga()
        {
			return new FeedItemViewModel(GetCommand())
            {
                AuthorPhoto = "michael.jpg",
                Date = DateTime.Now,
                AuthorName = "John McDonald",

                Content = "Now it's time to get in touch with your inner peace, huuummmmmm",
                ImageUrl = "yoga1.jpg",

                LikeCount = 1,
                EmojiTypes = new List<string> { "Wink.png" },
                CommentCount = 3
            };
        }
    }
}
