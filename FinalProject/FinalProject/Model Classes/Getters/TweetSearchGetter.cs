using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi.Models;

namespace FinalProject
{
    class TweetSearchGetter : TweetGetter
    {
        private Search search;

        public TweetSearchGetter(MessageFilter filter, Search s)
            : base(filter)
        {
            search = s;
        }

        public override List<ITweet> GetITweets()
        {
            return (search.Searched == String.Empty) ? new List<ITweet>() : Tweetinvi.Search.SearchTweets(search.Searched).ToList();
        }
    }
}
