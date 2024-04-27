using DataBase;
using DataBase.DbModels;
using System.Windows;
using System.Windows.Controls;

namespace CinemaWPF
{
    public partial class UserWindow : Window
    {
        private Customer Customer { get; set; }

        public UserWindow()
        {
            InitializeComponent();
        }
        public UserWindow(Customer customer)
        {
            InitializeComponent();
            Customer = customer;
            InitializeAsync();
        }



        private async void InitializeAsync()
        {
            var customers = await CinemaInfo.GetCustomersAsync();
            if (customers.Count == 0)
            {
                AddToDataBase();
            }
            else
            {
                var findedCustomer = customers.SingleOrDefault(x => x.ToString() == Customer.ToString());
                if (findedCustomer == null) AddToDataBase();
                else Customer = findedCustomer;
            }
        }
        private void AddToDataBase()
        {
            using (CinemaContext db = new())
            {
                db.Customers.Add(Customer);
                db.SaveChanges();
            }
        }
    }
}
