using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class UserWhitelistComponent : IFilterComponent
    {
        private List<string> usersToInclude;

        public UserWhitelistComponent(List<string> ids)
        {
            usersToInclude = ids;
        }

        //need to figure out how user ids are going to be passed around
        public void addToFilter(string id) { usersToInclude.Add(id); }

        public void removeFromFilter(string id)
        {
            if (usersToInclude.Contains(id)) { usersToInclude.Remove(id); }
        }

        public bool messagePassesFilter(Message message)
        {
            foreach (string id in usersToInclude)
            {
                //return true if the user authored the tweet
            }
            return false;
        }
    }
}
