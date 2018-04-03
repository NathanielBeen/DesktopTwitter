using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi.Models;

namespace FinalProject
{
    class Conversation : Message
    {
        public string Username { get; }

        public Conversation(string username)
            :base()
        {
            Username = username;
        }
    }
}
