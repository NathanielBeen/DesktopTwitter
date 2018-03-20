using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class WordWhitelistComponent : IFilterComponent
    {
        private List<string> wordsToInclude;

        public WordWhitelistComponent(List<string> words)
        {
            wordsToInclude = words;
        }

        public void addToFilter(string word) { wordsToInclude.Add(word); }

        public void removeFromFilter(string word)
        {
            if (wordsToInclude.Contains(word)){ wordsToInclude.Remove(word); }
        }

        public bool messagePassesFilter(Message message)
        {
            foreach (string word in wordsToInclude)
            {
                //return false if tweet doesnt contain word
            }
            return true;  
        }
    }
}
