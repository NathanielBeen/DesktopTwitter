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
        public MessageFilter Filter { get; set; }

        public TweetGetter(MessageFilter filter)
        {
            Filter = filter;
        }

        public List<Message> GetMessages()
        {
            List<ITweet> baseTweets = GetITweets();
            List<Message> constructedMessages = ConvertITweetsToMessages(baseTweets);
            List<Message> filteredMessages = FilterTweets(constructedMessages);
            return filteredMessages;
        }

        public virtual List<ITweet> GetITweets()
        {
            return new List<ITweet>();
        }

        /*
         * MS
         * Nice use of the Facade pattern. 
         * 
         * One common way of utilizing the Facade pattern would be to never
         * actually have a List<ITweet> but rather to automatically encapapsulate
         * the ITweet inside the Tweet (or Message) as soon as it is retrieved. 
         * 
         * That way you isolate the side effects of having the ITweet interface exposed
         * in your application. 
         *  
         */

        public List<Message> ConvertITweetsToMessages(List<ITweet> baseTweets)
        {
            var constructedMessages = new List<Message>();
            foreach (ITweet tweet in baseTweets)
            {
                constructedMessages.Add(new Tweet(tweet));
            }
            return constructedMessages;
        }

        public List<Message> FilterTweets(List<Message> constructedMessages)
        {
            if (Filter == null) { return constructedMessages; }

            var filteredMessages = new List<Message>();
            foreach (Message message in constructedMessages)
            {
                if (Filter.MessagePassesFilter(message)) { filteredMessages.Add(message); }
                //possibly add a default to note a tweet has been blocked
            }

            return filteredMessages;
        }
    }
}
