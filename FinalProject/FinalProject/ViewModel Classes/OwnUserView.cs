using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class OwnUserView : IUserView
    {
        private User currentUser;

        public string Username
        {
            get { return currentUser.Handle; }
        }

        public OwnUserView(User current)
        {
            currentUser = current;
        }
    }
}
