using DataBase;
using DataBase.DbModels;
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

            UserWindow userWindow = new(new(FirstNameInput.Text, LastNameInput.Text, EmailInput.Text, PhoneNumberInput.Text));
            Close();
            userWindow.ShowDialog();
        }
        private async void AdminLogIn(object sender, RoutedEventArgs e)
        {
            AdminLogInButton.IsEnabled = false;
            if (string.IsNullOrEmpty(LoginInput.Text)
                || string.IsNullOrEmpty(PasswordInput.Text))
            {
                MessageBox.Show("You have not filled all fields");
                AdminLogInButton.IsEnabled = true;
                return;
            }

            //var adminWindow = new AdminWindow();
            //Close();
            //adminWindow.ShowDialog();
        }
    }
}