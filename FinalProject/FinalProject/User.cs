using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi.Logic;

namespace FinalProject
{
    public class User
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Handle { get; set; }
        //public System.Drawing.Bitmap image { get; set; }

        public User(long id, string name, string handle)
        {
            ID = id;
            Name = name;
            Handle = handle;
        }
    }
}
