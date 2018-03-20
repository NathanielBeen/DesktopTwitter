using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi.Models;

namespace FinalProject
{
    class Conversations : Message
    {
        List<Message> conversation = new List<Message>();

        public Conversations(IUser sender, string text, long id, DateTime Time)
            :base()
        {

        }
    }
}
