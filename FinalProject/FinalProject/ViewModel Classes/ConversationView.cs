
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FinalProject
{
    class ConversationView : IMessageView
    {
        private Conversation conversation;

        public string Username
        {
            get { return conversation.Sender.ScreenName; }
        }

        private ClickDelegate clickDelegate;

        private ICommand selectUserCommand;
        public ICommand SelectUserCommand
        {
            get
            {
                return selectUserCommand ?? (selectUserCommand = new RelayCommand(() => HandleUserSelection()));
            }
        }
        public string GetMessageString()
        {
            return conversation.MessageString();
        }
        public ConversationView(Conversation c, ClickDelegate del)
        {
            conversation = c;
            clickDelegate = del;
        }

        public void HandleUserSelection()
        {
            var args = new ClickEventArgs(ClickType.ConversationSelect, Username);
            clickDelegate?.Invoke(args);
        }
    }
}
