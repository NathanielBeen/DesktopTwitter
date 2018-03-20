using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class MessageCollection
    {
        public ObservableCollection<Message> Messages { get; private set; }

        public MessageCollection()
        {
            //maybe create with a currentSelection object?
            Messages = new ObservableCollection<Message>(setMessages());
        }

        public List<Message> setMessages()
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
