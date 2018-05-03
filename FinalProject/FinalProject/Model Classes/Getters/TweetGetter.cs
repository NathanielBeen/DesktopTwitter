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
            }

            return filteredMessages;
        }
    }
}
