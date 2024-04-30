using DataBase;
using DataBase.DbModels;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace CinemaWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void UserLogIn(object sender, RoutedEventArgs e)
        {
            UserLogInButton.IsEnabled = false;
            if (string.IsNullOrEmpty(FirstNameInput.Text)
                || string.IsNullOrEmpty(LastNameInput.Text)
                || string.IsNullOrEmpty(EmailInput.Text)
                || string.IsNullOrEmpty(PhoneNumberInput.Text))
            {
                MessageBox.Show("You have not filled all fields");
                UserLogInButton.IsEnabled = true;
                return;
            }

            Customer customer = new(FirstNameInput.Text, LastNameInput.Text, EmailInput.Text, PhoneNumberInput.Text);
            UserWindow userWindow = new(customer);
            Close();
            userWindow.ShowDialog();
        }
        private async void AdminLogIn(object sender, RoutedEventArgs e)
        {
            AdminLogInButton.IsEnabled = false;
            AdminLogInWindow adminLogInWindow = new();
            Close();
            adminLogInWindow.ShowDialog();
        }
    }
}