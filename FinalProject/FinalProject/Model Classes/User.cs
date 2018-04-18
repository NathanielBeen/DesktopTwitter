using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
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
        public BitmapImage ProfilePic { get;}
        //public System.Drawing.Bitmap image { get; set; }

        public User(long id, string name, string handle)
        {
            TUser = Tweetinvi.User.GetUserFromScreenName(handle);
            ID = id;
            Name = name;
            Handle = handle;
            ProfilePic = GetProfilePic(TUser.ProfileImageUrl400x400);
        }

        public User(string username)
        {
            TUser = Tweetinvi.User.GetUserFromScreenName(username);
            ID = TUser.Id;
            Name = TUser.Name;
            Handle = TUser.ScreenName;
            ProfilePic = GetProfilePic(TUser.ProfileImageUrl400x400);
        }
        public BitmapImage GetProfilePic(string location)
        {
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(location, UriKind.Absolute);
            image.EndInit();
            return image;
        }
    }
}
