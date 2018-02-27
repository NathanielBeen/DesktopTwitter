using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class User
    {
        public string name { get; set; }
        public string handle { get; set; }
        public System.Drawing.Bitmap image { get; set; }

        public void Retweet(Tweet currentTweet)
        {
            int retweet = currentTweet.retweets;
            retweet += 1;
            currentTweet.retweets = retweet;
            /*Copy tweet body and then post it to timeline**/
        }
        public void Like(Tweet currentTweet)
        {
            int like = currentTweet.likes;
            like += 1;
            currentTweet.likes = like;
        }
        public void Logout()
        {

        }

    }
