using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi.Models;

namespace FinalProject
{
    class UserMessage : Message
    {
        public UserMessage(IUser user)
            :base(user.ScreenName, user, user.Id)
        {

        }
    }
}
