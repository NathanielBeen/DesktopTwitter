
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi.Models;
using System.IO;
using FinalProject.Properties;

namespace FinalProject
{
    public class Login
    {
        private Authentication authentication;
        public Account CurrentAccount
        {
            get; set; 
        }

        public Login()
        {
            authentication = new Authentication();
            ApplicationData.createFileIfNotPresent("Credentials.txt");
            ApplicationData.createFileIfNotPresent("MessageLog.txt");
        }

        public string RedirectToTwitter()
        {
            return authentication.RedirectToTwitter();
        }

        public bool CheckCredentials(Account account)
        {
            string tempName, tempPassword;
            String tempLine;
            StringReader reader = new StringReader(ApplicationData.readFromStoredFile("Credentials.txt"));
            tempLine = reader.ReadLine();

            while(tempLine != null)
            {
                var credentials = tempLine.Split(' ');
                if (credentials.Count() == 2)
                {
                    tempName = credentials[0];
                    tempPassword = credentials[1];

                    if (tempName.Equals(account.Username) && tempPassword.Equals(account.Password))
                    {
                        CurrentAccount = account;
                        return true;
                    }
                }

                tempLine = reader.ReadLine();
            }
            return false;
        }

        public CurrentUser AttemptLogin(StringInput pin)
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

        public bool CreateAccount(Account account)
        {
            if (account.Username == "" || account.Password == "") { return false; }

            ApplicationData.writeToStoredFile("Credentials.txt", account.Username + " " + account.Password);
            return true;
        }
    }
}
