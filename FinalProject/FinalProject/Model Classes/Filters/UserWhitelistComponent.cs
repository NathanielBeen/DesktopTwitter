﻿using System;
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

        public void ClearFilter() { usersToInclude.Clear(); }

        public bool MessagePassesFilter(Message message)
        {
            if (!usersToInclude.Any()) { return true; }
            foreach (FilterItem user in usersToInclude)
            {
                if (message.Sender.ScreenName == user.Content) { return true; }
            }
            return false;
        }

        public List<FilterItem> GetItems() { return usersToInclude; }
    }
}
