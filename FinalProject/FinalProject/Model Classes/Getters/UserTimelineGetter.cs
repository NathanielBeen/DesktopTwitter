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
        private User user;

        public UserTimelineGetter(MessageFilter filter, User u)
            :base(filter)
        {
            user = u;
        }

        public override List<ITweet> GetITweets()
        {
            return Timeline.GetUserTimeline(user.ID).ToList();
        }
    }
}
