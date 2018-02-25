using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    interface IMessageGetter
    {
        List<Message> Messages { get; set; }

        List<Message> getMessages();
    }
}
