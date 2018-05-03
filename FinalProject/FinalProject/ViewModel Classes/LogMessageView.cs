using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class LogMessageView : IMessageView
    {
        private LogMessage message;
        public string Text { get { return message.Text; } }

        public string Username { get { return message.Sender.Name; } }

        public LogMessageView(LogMessage m)
        {
            message = m;
        }

        public string GetMessageString()
        {
            return message.MessageString();
        }
    }
}
