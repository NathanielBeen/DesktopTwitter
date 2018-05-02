using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FinalProject
{
    public class WordWhitelistComponent : IFilterComponent
    {
        private List<FilterItem> wordsToInclude;

        public WordWhitelistComponent(List<FilterItem> words)
        {
            wordsToInclude = words;
        }

        public void AddToFilter(FilterItem word) { wordsToInclude.Add(word); }

        public void ClearFilter() { wordsToInclude.Clear(); }

        public bool MessagePassesFilter(Message message)
        {
            if (!wordsToInclude.Any()) { return true; }
            foreach (FilterItem word in wordsToInclude)
            {
                if (Regex.IsMatch(message.Text, string.Format(@"\b{0}\b", Regex.Escape(word.Content)))) { return true; }
            }
            return false;  
        }

        public List<string> getItems() { return (from item in wordsToInclude select item.Content).ToList(); }
    }
}
