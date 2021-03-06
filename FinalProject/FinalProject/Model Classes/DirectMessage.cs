﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Models;

namespace FinalProject
{
    public class DirectMessage : Message
    {
        public IUser Receiver { get; set; }
        public DateTime Time { get; set; }

        public DirectMessage(IMessage message)
            :base(message.Text, message.Sender, message.Id)
        {
            Receiver = message.Recipient;
            Time = message.CreatedAt;
        }
    }
}
