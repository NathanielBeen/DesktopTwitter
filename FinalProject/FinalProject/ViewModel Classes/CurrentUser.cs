﻿using System;
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

        public void Retweet(Tweet currentTweet)
        {
            int retweet = currentTweet.Retweets;
            retweet += 1;
            currentTweet.Retweets = retweet;
        }

        public void Like(Tweet currentTweet)
        {
            int like = currentTweet.Likes;
            like += 1;
            currentTweet.Likes = like;
        }

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
            return auth.FollowUser(selected.Name);
        }
        public bool UnfollowUser(User selected)
        {
            IAuthenticatedUser auth = Tweetinvi.User.GetAuthenticatedUser();
            return auth.UnFollowUser(selected.Name);
        }
        public void Logout()
        {

        }
    }
}
