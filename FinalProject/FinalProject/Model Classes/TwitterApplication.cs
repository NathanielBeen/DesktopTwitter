﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class TwitterApplication
    {
        public MessageFilter Filter { get; set; }
        public CurrentUser User { get; set; }

        public TwitterApplication(CurrentUser user)
        {
            Filter = new MessageFilter();
            User = user;
        }

        public List<Message> GetHomeTimeline()
        {
            var getter = new HomeTimelineGetter(Filter);
            return getter.GetMessages();
        }

        public List<Message> GetUserTimeline(User selectedUser)
        {
            var getter = new UserTimelineGetter(Filter, selectedUser);
            return getter.GetMessages();
        }

        public List<Message> GetConversations()
        {
            var getter = new ConversationGetter();
            return getter.GetMessages();
        }

        public List<Message> GetUserDMs(User selectedUser)
        {
            var getter = new DirectMessageGetter(selectedUser);
            return getter.GetMessages();
        }

        public List<Message> GetSearch(Search search)
        {
            if (search.TweetSearch)
            {
                var getter = new TweetSearchGetter(Filter, search);
                return getter.GetMessages();
            }
            else
            {
                var getter = new UserSearchGetter(search);
                return getter.GetMessages();
            }
        }
    }
}
