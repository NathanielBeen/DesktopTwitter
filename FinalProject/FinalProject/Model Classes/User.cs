using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi.Logic;
using Tweetinvi.Models;

namespace FinalProject
{
    public class User
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Handle { get; set; }
        public IUser TUser { get; }
        //public System.Drawing.Bitmap image { get; set; }

        public User(long id, string name, string handle)
        {
            TUser = Tweetinvi.User.GetUserFromScreenName(name);
            ID = id;
            Name = name;
            Handle = handle;
        }

        public User(string username)
        {
            TUser = Tweetinvi.User.GetUserFromScreenName(username);

            ID = TUser.Id;
            Name = TUser.Name;
            Handle = TUser.ScreenName;
        }
    }
}
