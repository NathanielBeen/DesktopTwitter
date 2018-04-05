
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

        private ClickDelegate clickDelegate;

        private ICommand selectUserCommand;
        public ICommand SelectUserCommand
        {
            get
            {
                return selectUserCommand ?? (selectUserCommand = new RelayCommand(() => HandleUserSelection()));
            }
        }

        public TweetView(Tweet t, ClickDelegate del)
        {
            tweet = t;
            clickDelegate = del;
        }

        public void HandleUserSelection()
        {
            var args = new ClickEventArgs(ClickType.UserSelect, Username);
            clickDelegate?.Invoke(args);
        }
    }
}
