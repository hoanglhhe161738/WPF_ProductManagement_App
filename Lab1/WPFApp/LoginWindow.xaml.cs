﻿using BusinessObjects;
using BusinessObjects.Models;
using Services;
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

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly IAccountService _accountService;
        public LoginWindow()
        {
            InitializeComponent();
            _accountService = new AccountService();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            int account = _accountService.GetAccountMember(txtUser.Text, txtPass.Password);
            if(account == 1)
            {
                this.Hide();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }else if( account == -1)
            {
                MessageBox.Show("Wrong username and password");

            }else if(account == -2)
            {
                MessageBox.Show("You are not permission");

            }

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
