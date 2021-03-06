﻿using System;
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

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for ApplicationLogin.xaml
    /// </summary>
    public partial class ApplicationLogin : Window
    {
        int viewMode;
        public const int LOGIN = 0;
        public const int SIGNUP = 1;
        private Login login;
        public ApplicationLogin()
        {
            login = new Login();
            viewMode = LOGIN;
            InitializeComponent();
            confirmPassword.Visibility = Visibility.Collapsed;
            textConPassword.Visibility = Visibility.Collapsed;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            Account test = new Account(textUsername.Text, textPassword.Text);
           if (login.CheckCredentials(test))
            {
                LoginWindow window = new LoginWindow(login);
                window.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password");
            }
        }

        private void CreateUserButton_Click(object sender, RoutedEventArgs e)
        {
            if(viewMode == LOGIN)
            {
                confirmPassword.Visibility = Visibility.Visible;
                textConPassword.Visibility = Visibility.Visible;
                loginButton.Visibility = Visibility.Collapsed;
                questionLabel.Visibility = Visibility.Collapsed;
                viewMode = SIGNUP;
            }

            else
            {
                Account test = new Account(textUsername.Text, textPassword.Text);
                if(textPassword.Text == textConPassword.Text && login.CreateAccount(test))
                {
                    confirmPassword.Visibility = Visibility.Collapsed;
                    textConPassword.Visibility = Visibility.Collapsed;
                    loginButton.Visibility = Visibility.Visible;
                    questionLabel.Visibility = Visibility.Visible;
                    viewMode = LOGIN;
                }
                else
                {
                    textPassword.Text = "";
                    textConPassword.Text = "";
                    MessageBox.Show("Passwords do not match.");
                }
            }
        }
    }
}
