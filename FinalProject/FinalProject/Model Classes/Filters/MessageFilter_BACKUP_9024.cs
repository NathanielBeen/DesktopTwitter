using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class MessageFilter
    {
        public Dictionary<FilterType, IFilterComponent> FilterComponents { get; }

        public MessageFilter()
        {
            FilterComponents = new Dictionary<FilterType, IFilterComponent>();
        }

        public void BuildOrUpdateComponent(FilterType filterType, List<FilterItem> itemsToFilter)
        {
<<<<<<< HEAD
            if (!itemsToFilter.Any())
=======
            if (!stringsToFilter.Any())
>>>>>>> origin/master
            {
                if (FilterComponents.ContainsKey(filterType)) { FilterComponents.Remove(filterType); }
            }

<<<<<<< HEAD
=======
            List<FilterItem> toFilter = BuildFilterItems(stringsToFilter);
>>>>>>> origin/master
            IFilterComponent component;
            switch (filterType)
            {
                case FilterType.WordWhiteList:
                    component = new WordWhitelistComponent(itemsToFilter);
                    break;
                case FilterType.WordBlackList:
                    component = new WordBlackListComponent(itemsToFilter);
                    break;
                case FilterType.UserWhiteList:
                    component = new UserWhitelistComponent(itemsToFilter);
                    break;
                case FilterType.UserBlackList:
                    component = new UserBlacklistComponent(itemsToFilter);
                    break;
                default:
                    return;
            }
            FilterComponents[filterType] = component;
        }

        public bool MessagePassesFilter(Message message)
        {
            foreach (IFilterComponent comp in FilterComponents.Values)
            {
                if (!comp.MessagePassesFilter(message)) { return false; }
            }

            return true;
        }
    }
}
