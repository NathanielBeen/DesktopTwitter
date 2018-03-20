using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class TweetView : IMessageView
    {
        private Tweet tweet;
        public int Retweets
        {
            get { return tweet.Retweets; }
        }

        public int Likes
        {
            get { return tweet.Likes; }
        }
        public string Text
        {
            get { return tweet.Text; }
        }
        public string Username
        {
            get { return tweet.Creator.ScreenName; }
        }
        public TweetView (Tweet t)
        {
            tweet = t;
        }
    }
}
