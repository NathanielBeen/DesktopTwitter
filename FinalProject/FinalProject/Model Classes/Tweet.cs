using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Models;

namespace FinalProject
{
    public class Tweet : Message
    {
        public int Likes { get; set; }
        public bool UserLiked { get; set; }
        public int Retweets { get; set; }
        public bool UserRetweeted { get; set; }
        public DateTime Time { get; set; }

        public Tweet(ITweet tweet)
            :base(tweet.Text, tweet.CreatedBy, tweet.Id)
        {
            Likes = tweet.FavoriteCount;
            UserLiked = tweet.Favorited;
            Retweets = tweet.RetweetCount;
            UserRetweeted = tweet.Retweeted;
            Time = tweet.CreatedAt;
        }

        public Tweet GetUpdatedMessage()
        {
            return new Tweet(Tweetinvi.Tweet.GetTweet(Id));
        }
    }
}
