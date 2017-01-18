using System;
using System.Collections.Generic;

namespace FBPlay
{
    public class FeedContentGenerator
    {
        public static FeedContentGenerator Instance = new FeedContentGenerator();

        List<Func<FeedItemViewModel>> _generators = new List<Func<FeedItemViewModel>>();
        Random _random = new Random();

        public FeedContentGenerator()
        {
            _generators.Add(Beach1);
            _generators.Add(Beach2);
            _generators.Add(Beach3);
            _generators.Add(Kid);
            _generators.Add(Yoga);
        }

        public List<IFeedItemViewModel> GenerateFeedItem(int count)
        {
            var items = new List<IFeedItemViewModel>();
            items.Add(new WhatOnYourMindViewModel() { AuthorPhoto = "michael.jpg"});

            for (int i = 1; i < count; i++)
            {
                var idx = (int)(_random.NextDouble() * 100) % 5;
                items.Add(_generators[idx]());
            }
            return items;
        }

        FeedItemViewModel Beach1()
        {
            return new FeedItemViewModel
            {
                AuthorPhoto = "michael.jpg",
                Date = DateTime.Now,
                AuthorName = "Peter Green",

                Content = "Life's a beach",
                ImageUrl = "beach1.jpeg",

                LikeCount = 2,
                CommentCount = 5
            };
        }

        FeedItemViewModel Beach2()
        {
            return new FeedItemViewModel
            {
                AuthorPhoto = "michael.jpg",
                Date = DateTime.Now,
                AuthorName = "Michael Ridland",

                Content = "This is where I write something great about my holiday!",
                ImageUrl = "beach2.jpg",

                LikeCount = 4,
                CommentCount = 9
            };
        }

        FeedItemViewModel Beach3()
        {
            return new FeedItemViewModel
            {
                AuthorPhoto = "michael.jpg",
                Date = DateTime.Now,
                AuthorName = "Mark James",

                Content = "Seriously how many holidays can you go on",
                ImageUrl = "beach3.jpeg",

                LikeCount = 1,
                CommentCount = 3
            };
        }

        FeedItemViewModel Kid()
        {
            return new FeedItemViewModel
            {
                AuthorPhoto = "michael.jpg",
                Date = DateTime.Now,
                AuthorName = "John McDonald",

                Content = "Why do people always have to upload pictures of there kids!",
                ImageUrl = "kid1.jpg",

                LikeCount = 1,
                CommentCount = 3
            };
        }

        FeedItemViewModel Yoga()
        {
            return new FeedItemViewModel
            {
                AuthorPhoto = "michael.jpg",
                Date = DateTime.Now,
                AuthorName = "John McDonald",

                Content = "Now it's time to get in touch with your inner peace, huuummmmmm",
                ImageUrl = "yoga1.jpg",

                LikeCount = 1,
                CommentCount = 3
            };
        }
    }
}
