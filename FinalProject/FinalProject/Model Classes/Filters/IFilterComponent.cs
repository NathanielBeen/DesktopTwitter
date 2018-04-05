using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public interface IFilterComponent
    {
        void AddToFilter(FilterItem item);
        void RemoveFromFilter(FilterItem item);

        bool MessagePassesFilter(Message message);
    }
}
