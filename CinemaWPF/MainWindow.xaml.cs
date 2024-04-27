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
            Customer customer = new(FirstNameInput.Text, LastNameInput.Text, EmailInput.Text, PhoneNumberInput.Text);

            var customers = await CinemaInfo.GetCustomersAsync();
            var findedCustomer = customers?.SingleOrDefault(x => x.ToString() == customer.ToString());
            if (findedCustomer != null) MessageBox.Show($"Hello {findedCustomer.FirstName} {findedCustomer.LastName}");
        }
        private async void AdminLogIn(object sender, RoutedEventArgs e)
        {
            AdminLogInButton.IsEnabled = false;

        }
    }
}