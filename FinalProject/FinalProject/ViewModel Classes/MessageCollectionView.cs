
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FinalProject
{
    public class MessageCollectionView
    {
        public ObservableCollection<IMessageView> Messages { get; }
        private TwitterApplication application;
        private ClickDelegate clickDelegate;

        private ICommand filterCommand;
        public ICommand FilterCommand { get { return filterCommand ?? (filterCommand = new RelayCommand(() => openFilterMenu())); } }

        private ICommand writeCommand;
        public ICommand WriteCommand { get { return writeCommand ?? (writeCommand = new RelayCommand(() => WriteToFile())); }}

        private ICommand readCommand;
        public ICommand ReadCommand { get { return readCommand ?? (readCommand = new RelayCommand(() => ReadFromFile())); } }

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
            else if (message is LogMessage) { return new LogMessageView((LogMessage)message); }
            else if (message is UserMessage) { return new UserMessageView((UserMessage)message, clickDelegate); }
            return null;
        }

        public void ChangeViewMode(ViewMode newMode, User selectedUser, Search search)
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
                case ViewMode.SearchView:
                    messageList = application.GetSearch(search);
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

        public void openFilterMenu()
        {
            clickDelegate?.Invoke(new ClickEventArgs(ClickType.OpenFilter, ""));
        }

        public void WriteToFile()
        {
            StreamWriter sr = new StreamWriter("../../MessageList.txt");
            foreach (IMessageView view in Messages)
            {
                sr.WriteLine(view.GetMessageString(), true);
            }
            sr.Close();
            MessageBox.Show("The Messages have succesfully been written to 'MessageList.txt'.");
        }

        public void ReadFromFile()
        {
            List<Message> messages = GetFileMessages();
            SetNewMessages(messages);
        }

        public List<Message> GetFileMessages()
        {
            var list = new List<Message>();
            StreamReader sr = new StreamReader("../../MessageList.txt");

            string line = sr.ReadLine();
            while (line != null)
            {
                LogMessage message = LogMessage.readFromLine(line);
                if (message != null) { list.Add(message); }
                line = sr.ReadLine();
            }
            sr.Close();
            return list;
        }
    }
}
