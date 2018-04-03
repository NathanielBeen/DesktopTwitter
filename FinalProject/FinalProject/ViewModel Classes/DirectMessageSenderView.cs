using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FinalProject
{
    class DirectMessageSenderView : ISenderView
    {
        private TwitterApplication application;

        public event PropertyChangedEventHandler PropertyChanged;
        private ICommand sendMessageCommand;
        public ICommand SendMessageCommand
        {
            get { return sendMessageCommand ?? (sendMessageCommand = new RelayCommand(() => sendMessage())); }
        }

        private string text;
        public string Text
        {
            get { return text; }
            set
            {
                if (value != text)
                {
                    text = value;
                    OnPropertyChanged(nameof(Text));
                }
            }
        }

        private string username;
        public string Username
        {
            get { return username; }
            set
            {
                if (value != username)
                {
                    username = value;
                    Text = "";
                    OnPropertyChanged(nameof(Username));
                }
            }
        }

        public DirectMessageSenderView(TwitterApplication app, string name)
        {
            application = app;
            Username = name;
        }

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void sendMessage()
        {
            var user = Tweetinvi.User.GetUserFromScreenName(username);
            var message = new GuiMessage(Text, user?.Id ?? 0);
            bool success = application.User.sendDirectMessage(message);

            if (success) { Text = "Message sent!"; }
        }
    }
}
