using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Models;

namespace FinalProject
{
    /*
     * Id - ITweet.ID
     * Text - ITweet.Text
     * User - ITweet.CreatedBy
     * possibly username, id?
     * Favorites - ITweet.FavoriteCount
     * Retweets - ITweet.RetweetCount
     * Mentions - ITweet.UserMentions
     * (for reply class) ITweet.RetweetedTweet
     */
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

        public Tweet getUpdatedMessage()
        {
            return new Tweet(Tweetinvi.Tweet.GetTweet(Id));
        }
    }
}
