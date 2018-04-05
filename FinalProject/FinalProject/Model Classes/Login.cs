using FinalProject.Model_Classes;
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

        public void RedirectToTwitter()
        {
            authentication.RedirectToTwitter();
        }

        public CurrentUser AttemptLogin(PIN pin)
        {
            authentication.RecievePin(pin);
            try
            {
                IAuthenticatedUser user = Tweetinvi.User.GetAuthenticatedUser();
                if (user == null) { return null; }
                else { return new CurrentUser(user); }
            }
            catch { return null; }
        }
    }
}
