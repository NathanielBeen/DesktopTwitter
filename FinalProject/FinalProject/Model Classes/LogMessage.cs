using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi.Models;

namespace FinalProject
{
    public class LogMessage : Message
    {
        public LogMessage(string text, IUser user)
            :base(text, user, 0)
        {

        }

        public static LogMessage readFromLine(string line)
        {
            string text = "";
            IUser user = null;
            string[] parts = line.Split(new string[] { ",.," }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Count() == 2)
            {
                string[] name_parts = parts[0].Split(new string[] { ",:," }, StringSplitOptions.RemoveEmptyEntries);
                string[] text_parts = parts[1].Split(new string[] { ",:," }, StringSplitOptions.RemoveEmptyEntries);
                if (name_parts.Count() == 2 && text_parts.Count() == 2)
                {
                    text = text_parts[1];
                    string username = name_parts[1];
                    user = Tweetinvi.User.GetUserFromScreenName(username);
                }
            }
            if (user == null) { return null; }
            return new LogMessage(text, user);
        }
    }
}
