using FinalProject.Model_Classes;
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
        public LoginWindow()
        {
            InitializeComponent();
            login = new Login();
            login.RedirectToTwitter();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            CurrentUser user = login.AttemptLogin(new PIN(pinTxt.Text));
            if (user == null) { NotifyInvalidLogin(); }
            else { launchMainWindow(user); }
        }

        private void NotifyInvalidLogin()
        {
            pinTxt.Text = "invalid login.";
            login.RedirectToTwitter();
        }

        private void launchMainWindow(CurrentUser user)
        {
            var main = new MainWindow(user);
            main.Show();
            Hide();
        }
    }
}
