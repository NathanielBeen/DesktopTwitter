using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FinalProject
{
    class UserMessageView : IMessageView
    {
        private UserMessage message;

        public string Username { get { return message.Text; } }
        public ImageBrush ProfilePic { get { return new ImageBrush(message.ProfilePic); } }

        private ClickDelegate clickDelegate;
        private ICommand selectuserCommand;
        public ICommand SelectUserCommand { get { return selectuserCommand ?? (selectuserCommand = new RelayCommand(() => HandleUserSelected())); } }

        public UserMessageView(UserMessage m, ClickDelegate del)
        {
            message = m;
            clickDelegate = del;
        }

        public void HandleUserSelected()
        {
            clickDelegate?.Invoke(new ClickEventArgs(ClickType.UserSelect, Username));
        }

        public string GetMessageString()
        {
            return message.MessageString();
        }
    }
}
