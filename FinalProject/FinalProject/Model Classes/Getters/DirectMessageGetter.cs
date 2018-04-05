using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi.Models;

namespace FinalProject
{
    class DirectMessageGetter : IMessageGetter
    {
        private User otherUser;

        public DirectMessageGetter(User other)
        {
            otherUser = other;
        }

        public List<Message> GetMessages()
        {

            var baseMessages = new List<IMessage>();
            var allMessagesRecieved = Tweetinvi.Message.GetLatestMessagesReceived();
            foreach (IMessage message in allMessagesRecieved)
            {
                if (message.SenderId == otherUser.ID) { baseMessages.Add(message); }
            }

            var allMessagesSent = Tweetinvi.Message.GetLatestMessagesSent();
            foreach (IMessage message in allMessagesSent)
            {
                if (message.RecipientId == otherUser.ID) { baseMessages.Add(message); }
            }

            baseMessages = (from message in baseMessages
                            orderby message.CreatedAt
                            select message).ToList();

            var constructedMessages = new List<Message>();
            foreach (IMessage message in baseMessages)
            {
                constructedMessages.Add(new DirectMessage(message));
            }

            return constructedMessages;
        }
    }
}
