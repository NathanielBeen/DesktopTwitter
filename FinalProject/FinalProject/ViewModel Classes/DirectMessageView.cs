using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class DirectMessageView : IMessageView
    {
        private DirectMessage message;
        private CurrentUser user;

        public string Text
        {
            get { return message.Text; }
        }

        public string Time
        {
            get { return message.Time.ToString(); }
        }

        public string Username
        {
            get { return (Sent) ? message.Receiver.ScreenName : message.Sender.ScreenName; }
        }

        public bool Sent
        {
            get { return (user.ID == message.Receiver.Id) ? false : true; }
        }

        public DirectMessageView(DirectMessage dm, CurrentUser u)
        {
            message = dm;
            user = u;
        }
        public string GetMessageString()
        {
            return message.MessageString();
        }
    }
}
