using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Models;

namespace FinalProject
{
    /*
     * ID - IMessage.ID
     * Text - IMessage.Text
     * Time - IMessage.CreatedAt
     * Reciever - IMessage.Recipient
     * Sender - IMessage.Sender
     */

    public class DirectMessage : Message
    {
        public IUser Receiver { get; set; }
        public IUser Sender { get; set; }
        public long Id { get; set; }
        public string Text { get; set; }
        public DateTime Time { get; set; }

        public DirectMessage(IMessage message, IUser sender, IUser receiver)
        {
            Text = message.Text;
            Id = message.Id;
            sender = Sender;
            receiver = Receiver;
            Time = message.CreatedAt;
        }
    }
}
