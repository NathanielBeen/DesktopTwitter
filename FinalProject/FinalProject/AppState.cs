using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi.Models;

namespace FinalProject
{
    public class AppState
    {
        //replace with user class once that is finished
        public IAuthenticatedUser CurrentUser { get; set; }

        public AppState(IAuthenticatedUser user)
        {
            CurrentUser = user;
        }
    }
}
