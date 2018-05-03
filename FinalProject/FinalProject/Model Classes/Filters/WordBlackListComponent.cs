using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FinalProject
{
    public class WordBlackListComponent : IFilterComponent
    {
        private List<FilterItem> wordsToExclude;

        public WordBlackListComponent(List<FilterItem> words)
        {
            wordsToExclude = words;
        }

        public void AddToFilter(FilterItem word) { wordsToExclude.Add(word); }

        public void ClearFilter() { wordsToExclude.Clear(); }

        public bool MessagePassesFilter(Message message)
        {
            if (!wordsToExclude.Any()) { return true; }
            foreach (FilterItem word in wordsToExclude)
            {
                if (Regex.IsMatch(message.Text, string.Format(@"\b{0}\b", Regex.Escape(word.Content)))) { return false; }
            }
            return true;
        }

        public List<FilterItem> GetItems() { return wordsToExclude; }
    }
}
