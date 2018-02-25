using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi.Models;

namespace FinalProject
{
    class PrivateMessageGetter : IMessageGetter
    {
        public List<Message> Messages { get; set; }

        public PrivateMessageGetter()
        {
            //inputs: user to get the conversation from
        }

        public List<Message> getMessages()
        {

            var baseMessages = new List<IMessage>();
            var allMessagesRecieved = Tweetinvi.Message.GetLatestMessagesReceived();
            foreach (IMessage message in allMessagesRecieved)
            {
                // if sender is other user, add to baseMessages
            }

            var allMessagesSent = Tweetinvi.Message.GetLatestMessagesSent();
            foreach (IMessage message in allMessagesSent)
            {
                //if reciever is other user, add to baseMessages
            }

            //order messages by time sent

            var constructedMessages = new List<Message>();
            foreach (IMessage message in baseMessages)
            {
                //convert to directmessage and add to constructedMessages
            }

            return constructedMessages;
        }
    }
}
