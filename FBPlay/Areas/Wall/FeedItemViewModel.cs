using System;

namespace FBPlay
{
    public class FeedItemViewModel
    {
        public string AuthorPhoto { get; set; }
        public DateTime Date { get; set; }
        public string AuthorName { get; set; }

        public string Content { get; set; }
        public string ImageUrl { get; set; }

        public int LikeCount { get; set; }
        public int CommentCount { get; set; }

        public FeedItemViewModel()
        {
        }
    }
}
