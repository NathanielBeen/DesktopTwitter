using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public void RemoveFromFilter(FilterItem word)
        {
            if (wordsToExclude.Contains(word)) { wordsToExclude.Remove(word); }
        }

        public bool MessagePassesFilter(Message message)
        {
            foreach (FilterItem word in wordsToExclude)
            {
                //return false if tweet contains word
            }
            return true;
        }
    }
}
