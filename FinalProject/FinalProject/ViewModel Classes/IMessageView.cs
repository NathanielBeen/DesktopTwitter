using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public interface IMessageView
    {
        /*
         * MS 4/8
         * Not sure you need this... however if you decided to use
         * an interface at this level what you might do is look for 
         * commonalities across your views and pull them up here. 
         * 
         * In this case, you might turn this into an IViewableMessageView 
         * for TweetView and ConversationView 
         * and another one for ISendableMessageView for 
         * DirectMessageSenderView 
         * 
         * Keep in mind that while you can't do multiple inheritance (i.e., 
         * you can't inherit from multiple parent classes) you CAN 
         * implement muliple interface.  So you might end up with a view
         * that is both IViewable* and ISendable*... and that's OK.  
         * 
         * But again... this is only if you decide you want to use an 
         * interface here. 
         */
        string GetMessageString();
    }
}
