using FinalProject.ViewModel_Classes;
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
            get { return tweet.Creator.ScreenName; }
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
            clickDelegate?.Invoke(MainWindowView.USER_SELECT, Username);
        }
    }
}
