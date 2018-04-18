using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Tweetinvi;
using Tweetinvi.Models;

namespace FinalProject
{
    public class Message
    {
        public string Text { get; set; }

        public IUser Sender { get; set; } 

        public long Id { get; set; }

        public BitmapImage ProfilePic { get; }

        public Message(string text, IUser sender, long id)
        {
            Text = text;
            Sender = sender;
            Id = id;
            ProfilePic = GetProfilePic(Sender.ProfileImageUrl400x400);
        }

        public string MessageString()
        {
            string handle = Sender.ScreenName;
            string message = "User Name,:," + handle + ",.," + " Message,:," + Text;
            return message;
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
