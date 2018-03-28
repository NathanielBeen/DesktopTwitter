using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class UserBlacklistComponent : IFilterComponent
    {
        private List<string> usersToExclude;

        public UserBlacklistComponent(List<string> ids)
        {
            usersToExclude = ids;
        }

        //need to figure out how user ids are going to be passed around
        public void addToFilter(string id) { usersToExclude.Add(id); }

        public void removeFromFilter(string id)
        {
            if (usersToExclude.Contains(id)) { usersToExclude.Remove(id); }
        }

        public bool messagePassesFilter(Message message)
        {
            foreach (string id in usersToExclude)
            {
                //return false if the user authored the message
            }
            return true;
        }
    }
}
