using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class MessageViewer
    {
        public List<Message> Messages { get; private set; }

        public MessageViewer()
        {
            //maybe create with a currentSelection object?
            Messages = getMessages();
        }

        public List<Message> getMessages()
        {
            IMessageGetter messageGetter = buildMessageGetter();
            return messageGetter.getMessages();
        }

        public IMessageGetter buildMessageGetter()
        {
            //pass in currentselection object
            //build getter depending on selections
            return null;
        }
    }
}
