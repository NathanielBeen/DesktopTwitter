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
        public Conversation(IUser user) : base("", user, 0) { }
    }
}
