using FinalProject.Model_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi.Models;
using System.IO;

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
        public bool CheckCredentials(string username, string password)
        {
            string tempName, tempPassword;
            String tempLine;
            StreamReader sr = new StreamReader("Credentials.txt");
            tempLine = sr.ReadLine();

            while(tempLine != null)
            {
                var credentials = tempLine.Split(" ");
                tempName = credentials[0];
                tempPassword = credentials[1];

                if(tempName.Equals(username) && tempPassword.Equals(password))
                {
                    return true;
                }

                tempLine = sr.ReadLine();
            }
            return false;
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
