using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi.Models;

namespace FinalProject
{
    class TweetReply : Tweet
    {
        public TweetReply(IUser sender, string text, long id, DateTime Time, int likes, int retweets) 
            :base(sender, text, id, Time, likes, retweets)
        {

        }
    }
}
