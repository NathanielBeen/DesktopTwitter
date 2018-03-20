using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Models;

namespace FinalProject
{
    class UserTimelineGetter : TweetGetter
    {
        //user to get the tweets from

        public UserTimelineGetter(MessageFilter filter)
            :base(filter)
        {
            //inputs: user to get tweets from
        }

        public override List<ITweet> getITweets()
        {
            //replace following with call to Timeline.GetUserTimeline(user_id)
            return base.getITweets();
        }
    }
}
