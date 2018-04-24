using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Search
    {
        public string Searched { get; set; }
        public bool TweetSearch { get; set; }

        public Search(string searched, bool tweetSearch)
        {
            Searched = searched;
            TweetSearch = tweetSearch;
        }
    }
}
