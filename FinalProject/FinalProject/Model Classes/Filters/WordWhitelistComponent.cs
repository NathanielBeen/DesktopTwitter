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

        public void RemoveFromFilter(FilterItem word)
        {
            if (wordsToInclude.Contains(word)){ wordsToInclude.Remove(word); }
        }

        public bool MessagePassesFilter(Message message)
        {
            foreach (FilterItem word in wordsToInclude)
            {
                if (Regex.IsMatch(message.Text, "\b" + word + "\b")) { return true; }
            }
            return false;  
        }

        public List<string> getItems() { return (from item in wordsToInclude select item.Content).ToList(); }
    }
}
