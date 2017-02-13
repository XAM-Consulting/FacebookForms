using System;
using Xamarin.Forms;

namespace FBPlay
{
    public interface IFeedItemViewModel
    {
        string AuthorPhoto { get; set; }
    }

    public class FeedItemViewModel : IFeedItemViewModel
    {
        public string AuthorPhoto { get; set; }
        public DateTime Date { get; set; }
        public string AuthorName { get; set; }

        public string Content { get; set; }
        public string ImageUrl { get; set; }

        public int LikeCount { get; set; }
        public int CommentCount { get; set; }

		public FeedItemViewModel(Command tappedCommand)
        {
			TappedCommand = tappedCommand;
        }

		public Command TappedCommand { get; set; }
    }

    public class WhatOnYourMindViewModel : IFeedItemViewModel
    {
        public string AuthorPhoto { get; set; }
    }
}
