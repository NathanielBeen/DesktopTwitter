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

    class DirectMessage : Message
    {
        public IUser Receiver { get; set; }

        public DirectMessage(IUser sender, string text, long id, DateTime Time, IUser receiver ) : base(sender, text, id, Time)
        {
        }
        
    }
}
