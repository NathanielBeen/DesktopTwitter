using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class UserBlacklistComponent : IFilterComponent
    {
        private List<FilterItem> usersToExclude;

        public UserBlacklistComponent(List<FilterItem> users)
        {
            usersToExclude = users;
        }

        //need to figure out how user ids are going to be passed around
        public void AddToFilter(FilterItem user) { usersToExclude.Add(user); }

        public void ClearFilter() { usersToExclude.Clear(); }

        public bool MessagePassesFilter(Message message)
        {
            if (!usersToExclude.Any()) { return true; }
            foreach (FilterItem user in usersToExclude)
            {
                if (message.Sender.ScreenName == user.Content) { return false; }
            }
            return true;
        }

        public List<string> getItems() { return (from item in usersToExclude select item.Content).ToList(); }
    }
}
