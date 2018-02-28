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
    class Tweet : Message
    {
        public int likes { get; set; }
        public int retweets { get; set; }

        public Tweet(IUser sender, string text, long id, DateTime Time, int likes, int retweets) : base(sender, text, id, Time)
        {

        }

    }
}
