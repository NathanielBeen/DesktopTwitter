using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi.Models;

namespace FinalProject
{
    class Retweet : Tweet
    {
        public ITweet RetweetedTweet { get; set; }
        
        public Retweet(ITweet tweet) 
            :base(tweet)
        {
            RetweetedTweet = tweet.RetweetedTweet;
        }
    }
}
