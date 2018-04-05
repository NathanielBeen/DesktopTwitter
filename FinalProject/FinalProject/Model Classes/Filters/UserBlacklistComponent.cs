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

        public UserBlacklistComponent(List<FilterItem> ids)
        {
            usersToExclude = ids;
        }

        //need to figure out how user ids are going to be passed around
        public void AddToFilter(FilterItem id) { usersToExclude.Add(id); }

        public void RemoveFromFilter(FilterItem id)
        {
            if (usersToExclude.Contains(id)) { usersToExclude.Remove(id); }
        }

        public bool MessagePassesFilter(Message message)
        {
            foreach (FilterItem id in usersToExclude)
            {
                //return false if the user authored the message
            }
            return true;
        }
    }
}
