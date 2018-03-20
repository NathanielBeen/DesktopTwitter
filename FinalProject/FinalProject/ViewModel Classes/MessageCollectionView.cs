using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class MessageCollectionView
    {
        public ObservableCollection<IMessageView> Messages { get; }
        private CurrentUser user;

        public MessageCollectionView()
        {
            //maybe create with a currentSelection object?
            Messages = new ObservableCollection<IMessageView>();
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
            if (message is Tweet) { return new TweetView((Tweet)message); }
            else if (message is DirectMessage) { return new DirectMessageView((DirectMessage)message, user); }
            return null;
        }

        public void SetCurrentUser(CurrentUser u) { user = u; }
    }
}
