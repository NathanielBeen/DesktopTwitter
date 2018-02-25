using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Models;

namespace FinalProject
{
    class HomeTimelineGetter : TweetGetter
    {

        public HomeTimelineGetter() : base() { }

        public override List<ITweet> getITweets()
        {
            return Timeline.GetHomeTimeline(100).ToList();
        }
    }
}
