using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FinalProject
{
    public class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }

        

        public Account(string name, string password)
        {
            Username = name;
            Password = password;
           
        }
    }
}
