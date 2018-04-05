using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class MessageFilter
    {
        public List<IFilterComponent> Components { get; set; }

        public MessageFilter()
        {
            Components = new List<IFilterComponent>();
        }

        public IFilterComponent BuildComponent(FilterType filterType, List<FilterItem> toFilter)
        {
            switch (filterType)
            {
                case FilterType.WordWhiteList:
                    return new WordWhitelistComponent(toFilter);
                case FilterType.WordBlackList:
                    return new WordBlackListComponent(toFilter);
                case FilterType.UserWhiteList:
                    return new UserWhitelistComponent(toFilter);
                case FilterType.UserBlackList:
                    return new UserBlacklistComponent(toFilter);
                default:
                    return null;
            }
        }

        public bool MessagePassesFilter(Message message)
        {
            foreach (IFilterComponent comp in Components)
            {
                if (!comp.MessagePassesFilter(message)) { return false; }
            }

            return true;
        }
    }
}
