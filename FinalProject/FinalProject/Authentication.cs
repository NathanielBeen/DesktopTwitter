using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;


namespace FinalProject
{
    class Authentication
    {
        public const string CONSUMERKEY;
        public const string CONSUMERSECRET;

        public TwitterCredentials AppCredentials { get; set; }

        public Authentication()
        {
            
        }
        public void login()
        {
            var url = CredentialsCreator.GetAuthorizationURL(AppCredentials);
            Process.Start(url);
        }
        public void RecievePin(string pin)
        {
            var userCredentials = CredentialsCreator.GetCredentialsFromVerifierCode(pin, AppCredentials);
            Auth.SetCredentials(userCredentials);
        }
    }
}
