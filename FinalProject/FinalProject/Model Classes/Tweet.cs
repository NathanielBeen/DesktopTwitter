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
        public int Retweets { get; set; }
        public string Text { get; set; }
        public long Id { get; set; }
        public IUser Creator { get; set; }
        public DateTime Time { get; set; }

        public Tweet(ITweet tweet)
        {
            Likes = tweet.FavoriteCount;
            Retweets = tweet.RetweetCount;
            Text = tweet.Text;
            Id = tweet.Id;
            Creator = tweet.CreatedBy;
            Time = tweet.CreatedAt;

        }

    }
}
