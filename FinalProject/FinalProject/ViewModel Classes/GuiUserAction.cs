using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class GuiUserAction
    {
        private TwitterApplication app;
        public User selectedUser { get; set; }

        public GuiUserAction(TwitterApplication ta)
        {
            app = ta;
            selectedUser = null;
        }

        public bool sendDirectMessage(string text)
        {
            var message = new GuiMessage(text, selectedUser.ID);
            return app.CurrentUser.sendDirectMessage(message);
        }
    }
}
