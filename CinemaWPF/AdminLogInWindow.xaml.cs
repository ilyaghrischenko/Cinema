﻿using DataBase;
using DataBase.DbModels;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace CinemaWPF
{
    public partial class AdminLogInWindow : Window
    {
        public AdminLogInWindow()
        {
            InitializeComponent();
        }

        private async void AdminLogIn(object sender, RoutedEventArgs e)
        {
            AdminLogInButton.IsEnabled = false;

            if (string.IsNullOrEmpty(LoginInput.Text)
                || string.IsNullOrEmpty(PasswordInput.Password))
            {
                MessageBox.Show("You have not filled all fields");
                AdminLogInButton.IsEnabled = true;
                return;
            }

            Admin admin = new(LoginInput.Text, PasswordInput.Password);
            try
            {
                if (!await admin.Check())
                {
                    MessageBox.Show("Incorrect data");
                    AdminLogInButton.IsEnabled = true;
                    return;
                }
            }
            catch (FileNotFoundException ex)
            {
                await ErrorLoger.LogErrorAsync("errors.json", ex);
                MessageBox.Show("Data not found");
                Close();
            }

            AdminWindow adminWindow = new();
            Close();
            adminWindow.ShowDialog();
        }
    }
}