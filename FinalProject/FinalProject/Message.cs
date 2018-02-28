using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Models;

namespace FinalProject
{
    class Message
    {
        public long ID { get; set; }
        public string Text { get; set; }
        public IUser Sender { get; set; }
        public DateTime Time { get; set; }

        public Message(IUser sender, string text, long id, DateTime Time)
        {

        }

    }
}
