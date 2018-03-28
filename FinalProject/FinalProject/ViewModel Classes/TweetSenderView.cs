using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FinalProject.ViewModel_Classes
{
    public class TweetSenderView : INotifyPropertyChanged
    {
        public const int MAX_LENGTH = 140;
        private TwitterApplication application;

        public event PropertyChangedEventHandler PropertyChanged;
        private ICommand sendTweetCommand;
        public ICommand SendTweetCommand
        {
            get { return sendTweetCommand ?? (sendTweetCommand = new RelayCommand(() => sendTweet())); }
        }


        private string text;
        public string Text
        {
            get { return text; }
            set
            {
                if (value != text && value.Count() <= MAX_LENGTH)
                {
                    NumChars = value.Count();
                    text = value;
                    OnPropertyChanged(nameof(Text));
                }
            }
        }

        private int numChars;
        public int NumChars
        {
            get { return numChars; }
            set
            {
                if (value != numChars && value <= MAX_LENGTH)
                {
                    numChars = value;
                    OnPropertyChanged(nameof(NumChars));
                }
            }
        }

        public TweetSenderView(TwitterApplication app, string username = "")
        {
            application = app;
            Text = "@"+username;
        }

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void sendTweet()
        {
            var message = new GuiMessage(Text, 0);
            bool success = application.User.sendTweet(message);

            if (success) { Text = "Tweet sent!"; }
        }
    }
}
