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
        public HomeTimelineGetter(MessageFilter filter) : base(filter) { }

        public override List<ITweet> GetITweets()
        {
            return Timeline.GetHomeTimeline().ToList();
        }
    }
}
