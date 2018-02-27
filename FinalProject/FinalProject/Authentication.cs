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
        private var context;
        public TwitterCredentials AppCredentials { get; set; }

        public Authentication()
        {
            
        }
        public void login()
        {
            context = AuthFlow.InitAuthentication(AppCredentials);
            Process.Start(context.AuthorizationURL);
        }
        public void RecievePin(string pin)
        {
            var userCredentials = AuthFlow.CreateCredentialsFromVerifierCode(pin, context);
            Auth.SetCredentials(userCredentials);
        }
        
    }
}
