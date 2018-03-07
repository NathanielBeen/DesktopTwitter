using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class TwitterApplication
    {
        public CurrentUser CurrentUser { get; set; }

        public TwitterApplication(CurrentUser user)
        {
            CurrentUser = user;
        }
    }
}
