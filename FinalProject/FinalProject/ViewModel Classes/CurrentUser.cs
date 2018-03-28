using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Models;

namespace FinalProject
{
    public class CurrentUser : User
    {
        public CurrentUser(IAuthenticatedUser user) : base(user.Id, user.Name, user.ScreenName) { }

        public void retweet(Tweet currentTweet)
        {
            int retweet = currentTweet.Retweets;
            retweet += 1;
            currentTweet.Retweets = retweet;
            /*Copy tweet body and then post it to timeline**/
        }

        public void like(Tweet currentTweet)
        {
            int like = currentTweet.Likes;
            like += 1;
            currentTweet.Likes = like;
        }

        public bool sendTweet(GuiMessage message)
        {
            var sentTweet = Tweetinvi.Tweet.PublishTweet(message.Text);
            return sentTweet?.IsTweetPublished ?? false;
        }

        public bool sendDirectMessage(GuiMessage message)
        {
            var sentMessage = Tweetinvi.Message.PublishMessage(message.Text, message.ID);
            return sentMessage.IsMessagePublished;
        }

        public void logout()
        {

        }
    }
}
