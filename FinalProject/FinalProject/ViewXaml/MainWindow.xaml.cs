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
using System.Windows.Shapes;
using Tweetinvi.Models;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowView view;

        public MainWindow(CurrentUser user, Account account)
        {
            view = new MainWindowView(new TwitterApplication(user), account);
            view.SelectedUser = user;
            InitializeComponent();

            DataContext = view;
        }
    }
}
