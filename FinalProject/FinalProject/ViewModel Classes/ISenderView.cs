using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public interface ISenderView : INotifyPropertyChanged
    {
        string Text { get; set; }
        void SendMessage();
    }
}
