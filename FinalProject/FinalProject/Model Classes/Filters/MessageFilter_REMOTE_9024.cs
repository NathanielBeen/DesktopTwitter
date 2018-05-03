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

        public void BuildOrUpdateComponent(FilterType filterType, List<string> stringsToFilter)
        {
            if (!stringsToFilter.Any())
            {
                if (FilterComponents.ContainsKey(filterType)) { FilterComponents.Remove(filterType); }
            }

            List<FilterItem> toFilter = BuildFilterItems(stringsToFilter);
            IFilterComponent component;
            switch (filterType)
            {
                case FilterType.WordWhiteList:
                    component = new WordWhitelistComponent(toFilter);
                    break;
                case FilterType.WordBlackList:
                    component = new WordBlackListComponent(toFilter);
                    break;
                case FilterType.UserWhiteList:
                    component = new UserWhitelistComponent(toFilter);
                    break;
                case FilterType.UserBlackList:
                    component = new UserBlacklistComponent(toFilter);
                    break;
                default:
                    return;
            }
            FilterComponents[filterType] = component;
        }

        public List<FilterItem> BuildFilterItems(List<string> items)
        {
            var filterItems = new List<FilterItem>();
            foreach (string item in items) { filterItems.Add(new FilterItem(item)); }
            return filterItems;
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
