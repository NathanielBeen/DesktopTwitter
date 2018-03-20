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
        //reference to search object

        public TweetSearchGetter(MessageFilter filter)
            : base(filter)
        {
            //inputs: search object
        }

        public override List<ITweet> getITweets()
        {
            //replace following with a call to the search getSearchedTweets()
            return base.getITweets();
        }
    }
}
