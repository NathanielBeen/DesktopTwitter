
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FinalProject
{
    public class TweetView : IMessageView
    {
        private Tweet tweet;
        public int Retweets
        {
            get { return tweet.Retweets; }
        }

        public int Likes
        {
            get { return tweet.Likes; }
        }

        public string Text
        {
            get { return tweet.Text; }
        }

        public string Username
        {
            get { return tweet.Sender.ScreenName; }
        }

        public bool CurrentLiked
        {
            get { return tweet.UserLiked; }
        }

        public bool CurrentRetweeted
        {
            get { return tweet.UserRetweeted; }
        }

        private ClickDelegate userClickDelegate;
        private ICommand selectUserCommand;
        public ICommand SelectUserCommand
        {
            get
            {
                return selectUserCommand ?? (selectUserCommand = new RelayCommand(() => HandleUserSelection()));
            }
        }

        private TweetDelegate tweetDelegate;
        private ICommand likeTweetCommand;
        public ICommand LikeTweetCommand
        {
            get
            {
                return likeTweetCommand ?? (likeTweetCommand = new RelayCommand(() => HandleTweetLiked()));
            }
        }

        private ICommand retweetTweetCommand;
        public ICommand RetweetTweetCommand
        {
            get
            {
                return retweetTweetCommand ?? (retweetTweetCommand = new RelayCommand(() => HandleTweetRetweet()));
            }
        }

        public TweetView(Tweet t, ClickDelegate userDel, TweetDelegate tweetDel)
        {
            tweet = t;
            userClickDelegate = userDel;
            tweetDelegate = tweetDel;
        }

        public TweetView CreateUpdatedView()
        {
            return new TweetView(tweet.getUpdatedMessage(), userClickDelegate, tweetDelegate);
        }

        public void HandleUserSelection()
        {
            var args = new ClickEventArgs(ClickType.UserSelect, Username);
            userClickDelegate?.Invoke(args);
        }

        public void HandleTweetLiked()
        {
            var args = new TweetEventArgs(ClickType.TweetLike, this, tweet);
            tweetDelegate?.Invoke(args);
        }

        public void HandleTweetRetweet()
        {
            var args = new TweetEventArgs(ClickType.TweetRetweet, this, tweet);
            tweetDelegate?.Invoke(args);
        }
    }
}
