using System;
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

        public TwitterApplication(CurrentUser user) { User = user; }

        public List<Message> getHomeTimeline()
        {
            var getter = new HomeTimelineGetter(Filter);
            return getter.getMessages();
        }

        public List<Message> getUserTimeline(User selectedUser)
        {
            var getter = new UserTimelineGetter(Filter, selectedUser);
            return getter.getMessages();
        }
    }
}
