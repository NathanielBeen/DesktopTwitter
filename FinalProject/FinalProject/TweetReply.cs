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
        public long? RepliedTweetID { get; set; }
        
        public TweetReply(ITweet tweet) 
            :base(tweet)
        {
            RepliedTweetID = tweet.InReplyToStatusId;
        }
    }
}
