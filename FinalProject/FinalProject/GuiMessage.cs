using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class GuiMessage
    {
        public string Text { get; set; }
        public long ID { get; set; }

        public GuiMessage(string text, long id)
        {
            Text = text;
            ID = id;
        }
    }
}
