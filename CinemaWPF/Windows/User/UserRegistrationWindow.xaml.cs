using System.Windows;
using DataBase;
using DataBase.DbModels;

namespace CinemaWPF.Windows.User
{
    public partial class UserRegistrationWindow : Window
    {
        public UserRegistrationWindow()
        {
            InitializeComponent();
        }

        private async void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FirstNameInput.Text)
               || string.IsNullOrWhiteSpace(LastNameInput.Text)
               || string.IsNullOrEmpty(EmailInput.Text)
               || string.IsNullOrEmpty(PhoneNumberInput.Text))
            {
                MessageBox.Show("You have not filled all fields");
                return;
            }

            Customer? customer = null;
            var customers = await CinemaInfo.GetCustomersAsync();
            var findedCustoemer = customers.FirstOrDefault(x => x.Email == EmailInput.Text && x.PhoneNumber == PhoneNumberInput.Text);
            if (findedCustoemer != null)
            {
                MessageBox.Show("Customer with this email and phone number already exist");
                EmailInput.Clear();
                PhoneNumberInput.Clear();
                return;
            }
            else
            {
                try
                {
                    customer = new(FirstNameInput.Text, LastNameInput.Text, EmailInput.Text, PhoneNumberInput.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                using CinemaContext db = new();
                db.Customers.Add(customer);
                await db.SaveChangesAsync();

                MessageBox.Show("You have successfully sign up");
                UserWindow window = new(customer);
                Close();
                window.ShowDialog();
            }
        }
    }
}
