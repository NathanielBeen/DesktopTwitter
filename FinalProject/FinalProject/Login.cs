using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi.Models;

namespace FinalProject
{
    class Login
    {
        private Authentication authentication;

        public Login()
        {
            authentication = new Authentication();
        }

        public void redirectToTwitter()
        {
            authentication.redirectToTwitter();
        }

        public AppState attemptLogin(string pin)
        {
            authentication.recievePin(pin);
            try
            {
                IAuthenticatedUser user = Tweetinvi.User.GetAuthenticatedUser();
                if (user == null) { return null; }
                else { return new AppState(user); }
            }
            catch { return null; }
        }
    }
}
