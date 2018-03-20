using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    interface IFilterComponent
    {
        void addToFilter(string s);
        void removeFromFilter(string s);

        bool messagePassesFilter(Message message);
    }
}
