using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi.Models;

namespace FinalProject
{
    class ConversationGetter : IMessageGetter
    {
        public ConversationGetter() { }

        public List<Message> GetMessages()
        {
            var allMessagesRecieved = Tweetinvi.Message.GetLatestMessagesReceived();
            var allMessagesSent = Tweetinvi.Message.GetLatestMessagesSent();
            var allSendingUserIds = (from message in allMessagesRecieved.Union(allMessagesSent)
                                     orderby message.CreatedAt descending
                                     select message.RecipientId).Distinct();

            var constructedMessages = new List<Message>();
            foreach (long id in allSendingUserIds)
            {
               var user = Tweetinvi.User.GetUserFromId(id);
                constructedMessages.Add(new Conversation(user));
            }

            return constructedMessages;
        }
    }
}
