
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
using Tweetinvi.Models;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private Login login;
        public LoginWindow(Login l)
        {
            InitializeComponent();
            login = l;
            browser.Navigate(login.RedirectToTwitter());

        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            CurrentUser user = login.AttemptLogin(new StringInput(pinTxt.Text));

            if (user == null) { NotifyInvalidLogin(); }
            else { LaunchMainWindow(user); }
        }

        private void NotifyInvalidLogin()
        {
            pinTxt.Text = "invalid login.";
            login.RedirectToTwitter();
        }

        private void LaunchMainWindow(CurrentUser user)
        {
            var main = new MainWindow(user, login.CurrentAccount);
            main.Show();
            Close();

            

            /*
             * MS
             * When I close the MainWindow the application doesn't close
             * The reason is you have hidden this window which keeps the thread
             * going even if the MainWindow gets killed.
             * 
             * You can tap into the MainWindows.Closed event to throw control back to this 
             * window and either show it again so someone else can log in
             * or you can just close this window. 
             */
        }
    }
}
