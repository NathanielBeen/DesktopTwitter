using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
