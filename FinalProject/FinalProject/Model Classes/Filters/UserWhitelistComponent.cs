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

        public UserWhitelistComponent(List<FilterItem> ids)
        {
            usersToInclude = ids;
        }

        //need to figure out how user ids are going to be passed around
        public void AddToFilter(FilterItem id) { usersToInclude.Add(id); }

        public void RemoveFromFilter(FilterItem id)
        {
            if (usersToInclude.Contains(id)) { usersToInclude.Remove(id); }
        }

        public bool MessagePassesFilter(Message message)
        {
            foreach (FilterItem id in usersToInclude)
            {
                //return true if the user authored the tweet
            }
            return false;
        }
    }
}
