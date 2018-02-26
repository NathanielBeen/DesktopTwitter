using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class WordBlackListComponent : IFilterComponent
    {
        private List<string> wordsToExclude;

        public WordBlackListComponent(List<string> words)
        {
            wordsToExclude = words;
        }

        public void addToFilter(string word) { wordsToExclude.Add(word); }

        public void removeFromFilter(string word)
        {
            if (wordsToExclude.Contains(word)) { wordsToExclude.Remove(word); }
        }

        public bool messagePassesFilter(Message message)
        {
            foreach (string word in wordsToExclude)
            {
                //return false if tweet contains word
            }
            return true;
        }
    }
}
