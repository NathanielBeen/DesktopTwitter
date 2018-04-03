﻿
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
            get { return conversation.Username; }
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

        public ConversationView(Conversation c, ClickDelegate del)
        {
            conversation = c;
            clickDelegate = del;
        }

        public void HandleUserSelection()
        {
            clickDelegate?.Invoke(MainWindowView.CONVO_SELECT, Username);
        }
    }
}
