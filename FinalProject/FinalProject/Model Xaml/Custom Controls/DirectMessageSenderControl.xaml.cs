using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for MessageSenderControl.xaml
    /// </summary>
    public partial class DirectMessageSenderControl : UserControl
    {
        public GuiUserAction UserAction { get; set; }

        public DirectMessageSenderControl()
        {
            InitializeComponent();
        }

        private void send_Click(object sender, RoutedEventArgs e)
        {
            bool success = UserAction.sendDirectMessage(messageContent.Text);
        }
    }
}
