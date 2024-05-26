using CinemaWPF.Windows.User;
using DataBase;
using DataBase.DbModels;
using System.Windows;

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
            if (string.IsNullOrEmpty(EmailInput.Text)
               || string.IsNullOrEmpty(PhoneNumberInput.Text))
            {
                MessageBox.Show("You have not filled all fields");
                UserLogInButton.IsEnabled = true;
                return;
            }

            Customer? customer = null;
            using CinemaContext db = new();
            var findedCustomer = db.Customers.SingleOrDefault(x => x.Email == EmailInput.Text && x.PhoneNumber == PhoneNumberInput.Text);
            if (findedCustomer == null)
            {
                MessageBox.Show("User with this info does not exist. If you want to registrate click on the button below");
                EmailInput.Clear();
                PhoneNumberInput.Clear();
                return;
            }
            else
            {
                customer = findedCustomer;
                MessageBox.Show("You have successfully logged in");
                UserWindow userWindow = new(customer);
                Close();
                userWindow.ShowDialog();
            }
        }
        private async void AdminLogIn(object sender, RoutedEventArgs e)
        {
            AdminLogInWindow adminLogInWindow = new();
            Close();
            adminLogInWindow.ShowDialog();
        }

        private async void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            UserRegistrationWindow window = new();
            Close();
            window.ShowDialog();
        }
    }
}