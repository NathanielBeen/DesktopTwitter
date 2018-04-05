using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class ClickEventArgs
    {
        public ClickType Type { get; set; }
        public string Value { get; set; }

        public ClickEventArgs(ClickType type, string value)
        {
            Type = type;
            Value = value;
        }
    }
}
