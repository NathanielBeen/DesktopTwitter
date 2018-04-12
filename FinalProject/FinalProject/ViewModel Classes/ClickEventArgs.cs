using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class ClickEventArgs
    {
        public ClickType Type { get; set; }
        public string Value { get; set; }

        public ClickEventArgs(ClickType type, string value)
        {
            Type = type;
            Value = value;
        }
    }

    public class TweetEventArgs
    {
        public ClickType Type { get; set; }
        public TweetView View { get; set; }
        public Tweet Tweet { get; set; }

        public TweetEventArgs(ClickType type, TweetView view, Tweet tweet)
        {
            Type = type;
            View = view;
            Tweet = tweet;
        }
    }
}
