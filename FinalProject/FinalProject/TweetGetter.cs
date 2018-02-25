using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Models;

namespace FinalProject
{
    class TweetGetter : IMessageGetter
    {
        public List<Message> Messages { get; set; }
        //add reference to filter

        public TweetGetter() { }

        public List<Message> getMessages()
        {
            List<ITweet> baseTweets = getITweets();
            List<Message> constructedMessages = convertITweetsToMessages(baseTweets);
            //filter messages

            return constructedMessages;
        }

        public virtual List<ITweet> getITweets()
        {
            return new List<ITweet>();
        }

        public List<Message> convertITweetsToMessages(List<ITweet> baseTweets)
        {
            var constructedMessages = new List<Message>();
            foreach (ITweet tweet in baseTweets)
            {
                //convert to tweet, add to constructedMessags
            }
            return constructedMessages;
        }
    }
}
