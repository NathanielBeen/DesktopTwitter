using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FinalProject
{
    class OwnUserView : IUserView
    {
        private User currentUser;

        public string Username
        {
            get { return currentUser.Handle; }
        }
        public ImageBrush ProfilePic { get { return new ImageBrush(currentUser.ProfilePic); } }

        public OwnUserView(User current)
        {
            currentUser = current;
        }
    }
}
