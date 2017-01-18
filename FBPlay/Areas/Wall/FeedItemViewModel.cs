using System;
using System.Collections.Generic;

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

        public List<string> EmojiTypes { get; set; }

        public FeedItemViewModel()
        {
        }
    }

    public class WhatOnYourMindViewModel : IFeedItemViewModel
    {
        public string AuthorPhoto { get; set; }
    }
}
