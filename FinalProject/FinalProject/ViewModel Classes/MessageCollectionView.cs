
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FinalProject
{
    public class MessageCollectionView
    {
        public ObservableCollection<IMessageView> Messages { get; }
        private TwitterApplication application;
        private ClickDelegate clickDelegate;
        private ICommand filecommand;
        public ICommand FileCommand { get { return filecommand ?? (filecommand = new RelayCommand(() => WriteToFile())); }}

        public MessageCollectionView(TwitterApplication app, ClickDelegate click)
        {
            //maybe create with a currentSelection object?
            Messages = new ObservableCollection<IMessageView>();

            application = app;
            clickDelegate = click;
        }
    
        public void SetNewMessages(List<Message> modelMessages)
        {
            var messages = new List<IMessageView>();
            foreach (Message m in modelMessages)
            {
                var message = BuildMessage(m);
                if (message != null) { messages.Add(message); }
            }

            Messages.Clear();
            foreach (IMessageView m in messages) { Messages.Add(m); }
        }

        public IMessageView BuildMessage(Message message)
        {
            if (message is Tweet) { return new TweetView((Tweet)message, clickDelegate, HandleTweetEvent); }
            else if (message is DirectMessage) { return new DirectMessageView((DirectMessage)message, application.User); }
            else if (message is Conversation) { return new ConversationView((Conversation)message, clickDelegate); }
            return null;
        }

        public void ChangeViewMode(ViewMode newMode, User selectedUser)
        {
            var messageList = new List<Message>();
            switch (newMode)
            {
                case ViewMode.MainView:
                    messageList = application.GetHomeTimeline();
                    break;
                case ViewMode.UserView:
                    messageList = application.GetUserTimeline(selectedUser);
                    break;
                case ViewMode.ConversationView:
                    messageList = application.GetConversations();
                    break;
                case ViewMode.DMView:
                    messageList = application.GetUserDMs(selectedUser);
                    break;
            }

            SetNewMessages(messageList);
        }

        public void HandleTweetEvent(TweetEventArgs args)
        {
            switch (args.Type)
            {
                case ClickType.TweetLike:
                    application.User.LikeTweet(args.Tweet);
                    break;
                case ClickType.TweetRetweet:
                    application.User.RetweetTweet(args.Tweet);
                    break;
                default:
                    return;
            }
            UpdateMessage(args.View);
        }

        public void UpdateMessage(IMessageView to_update)
        {
            if (Messages.Contains(to_update))
            {
                int pos = Messages.IndexOf(to_update);
                Messages.Remove(to_update);
                to_update = (to_update as TweetView)?.CreateUpdatedView() ?? to_update;
                Messages.Insert(pos, to_update);
            }
        }
        public void WriteToFile()
        {
            StreamWriter sr = new StreamWriter("../../MessageList.txt");
            foreach (IMessageView view in Messages)
            {
                sr.WriteLine(view.GetMessageString(), true);
            }
            sr.Close();
        }
    }
}
