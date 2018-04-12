using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Models;

namespace FinalProject
{
    public class Message
    {
        public string Text { get; set; }

        public IUser Sender { get; set; } 

        public long Id { get; set; }

        public Message(string text, IUser sender, long id)
        {
            Text = text;
            Sender = sender;
            Id = id;
        }
        public string MessageString()
        {
            string name = Sender.Name;
            string message = "User Name:" + name +" Message: " + Text;
            return message;
        }
    }
}
