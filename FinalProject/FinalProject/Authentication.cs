using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Models;

namespace FinalProject
{
    class Authentication
    {
        public const string CONSUMERKEY = "uSYb0gVx77xi0LEF8uhhDwu6m";
        public const string CONSUMERSECRET = "LZRu8wZwjQlo7373RA9MDI3hDWNSVmA4aIUNFI6xemR62xgxXV";
        private IAuthenticationContext context;
        public TwitterCredentials AppCredentials { get; set; }

        public Authentication()
        {
            AppCredentials = new TwitterCredentials(CONSUMERKEY, CONSUMERSECRET);
            login();
        }

        public void login()
        {
            context = AuthFlow.InitAuthentication(AppCredentials);
            Process.Start(context.AuthorizationURL);
        }

        public void recievePin(string pin)
        {
            var userCredentials = AuthFlow.CreateCredentialsFromVerifierCode(pin, context);
            Auth.SetCredentials(userCredentials);
        }
        
    }
}
