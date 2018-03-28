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

        public List<Message> getMessages()
        {
            List<ITweet> baseTweets = getITweets();
            List<Message> constructedMessages = convertITweetsToMessages(baseTweets);
            List<Message> filteredMessages = filterTweets(constructedMessages);
            return filteredMessages;
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
                constructedMessages.Add(new Tweet(tweet));
            }
            return constructedMessages;
        }

        public List<Message> filterTweets(List<Message> constructedMessages)
        {
            if (Filter == null) { return constructedMessages; }

            var filteredMessages = new List<Message>();
            foreach (Message message in constructedMessages)
            {
                if (Filter.messagePassesFilter(message)) { filteredMessages.Add(message); }
                //possibly add a default to note a tweet has been blocked
            }

            return filteredMessages;
        }
    }
}
