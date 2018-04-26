using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class UserWhitelistComponent : IFilterComponent
    {
        private List<FilterItem> usersToInclude;

        public UserWhitelistComponent(List<FilterItem> users)
        {
            usersToInclude = users;
        }

        public void AddToFilter(FilterItem user) { usersToInclude.Add(user); }

        public void RemoveFromFilter(FilterItem user)
        {
            if (usersToInclude.Contains(user)) { usersToInclude.Remove(user); }
        }

        public bool MessagePassesFilter(Message message)
        {
            foreach (FilterItem user in usersToInclude)
            {
                if (message.Sender.ScreenName == user.Content) { return true; }
            }
            return false;
        }

        public List<string> getItems() { return (from item in usersToInclude select item.Content).ToList(); }
    }
}
