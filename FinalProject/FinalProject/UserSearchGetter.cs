using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi.Models;

namespace FinalProject
{
    class UserSearchGetter : IMessageGetter
    {
        private Search search;

        public UserSearchGetter(Search s)
        {
            search = s;
        }

        public List<Message> GetMessages()
        {
            List<Message> userMessages = new List<Message>();
            List<IUser> users = Tweetinvi.Search.SearchUsers(search.Searched).ToList();
            foreach (IUser user in users)
            {
                userMessages.Add(new UserMessage(user));
            }

            return userMessages;
        }
    }
}
