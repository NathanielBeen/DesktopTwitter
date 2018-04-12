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

        public bool SendTweet(GuiMessage message)
        {
            var sentTweet = Tweetinvi.Tweet.PublishTweet(message.Text);
            return sentTweet?.IsTweetPublished ?? false;
        }

        public bool SendDirectMessage(GuiMessage message)
        {
            var sentMessage = Tweetinvi.Message.PublishMessage(message.Text, message.ID);
            return sentMessage.IsMessagePublished;
        }

        public bool FollowUser(User selected)
        {
            IAuthenticatedUser auth = Tweetinvi.User.GetAuthenticatedUser();
            return auth.FollowUser(selected.Handle);
        }
        public bool UnfollowUser(User selected)
        {
            IAuthenticatedUser auth = Tweetinvi.User.GetAuthenticatedUser();
            return auth.UnFollowUser(selected.Handle);
        }
        
        public bool LikeTweet(Tweet tweet)
        {
            var baseTweet = Tweetinvi.Tweet.GetTweet(tweet.Id);
            if (baseTweet.Favorited) { return Tweetinvi.Tweet.UnFavoriteTweet(baseTweet); }
            else { return Tweetinvi.Tweet.FavoriteTweet(baseTweet); }
        }

        public bool RetweetTweet(Tweet tweet)
        {
            var baseTweet = Tweetinvi.Tweet.GetTweet(tweet.Id);
            if (baseTweet.Retweeted) { return Tweetinvi.Tweet.UnRetweet(baseTweet); }
            else { return Tweetinvi.Tweet.PublishRetweet(baseTweet).IsTweetPublished; }
        }
    }
}
