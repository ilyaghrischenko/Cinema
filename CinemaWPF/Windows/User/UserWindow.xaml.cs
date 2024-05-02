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
            TicketButton.IsEnabled = false;
            Customer = customer;
            GetSessionsAsync();
        }

        private async void GetSessionsAsync()
        => SessionsList.ItemsSource = await CinemaInfo.GetSessionsAsync();

        private async void TextChanged(object sender, TextChangedEventArgs e)
        => TicketButton.IsEnabled = !string.IsNullOrEmpty(SeatNumberInput.Text);

        private async void TicketBuy(object sender, RoutedEventArgs e)
        {
            TicketButton.IsEnabled = false;

            if (SessionsList.SelectedItem == null)
            {
                MessageBox.Show("You have not chosen a session");
                TicketButton.IsEnabled = true;
                return;
            }
            if (string.IsNullOrEmpty(SeatNumberInput.Text))
            {
                MessageBox.Show("You have not filled all fields");
                TicketButton.IsEnabled = true;
                return;
            }

            var chosenSession = SessionsList.SelectedItem as Session;
            if (!uint.TryParse(SeatNumberInput.Text, out uint seatNumber))
            {
                MessageBox.Show("Invalid seat number input");
                SeatNumberInput.Clear();
                TicketButton.IsEnabled = true;
                return;
            }

            var tickets = await CinemaInfo.GetTicketsAsync();
            if (tickets.Count > 0)
            {
                var ticket = tickets.SingleOrDefault(x => x.Session.Equals(chosenSession) && x.SeatNumber == seatNumber);
                if (ticket != null)
                {
                    MessageBox.Show("Ticket with this seat number on this session already exist");
                    SeatNumberInput.Clear();
                    TicketButton.IsEnabled = true;
                    return;
                }
            }

            using (CinemaContext db = new())
            {
                Ticket newTicket = new(db.Sessions.First(x => x.Equals(chosenSession)), seatNumber, db.Customers.First(x => x.Equals(Customer)), DateTime.Now);
                db.Tickets.Add(newTicket);
                db.SaveChanges();
            }
            MessageBox.Show("You have successfully purchased a ticket");
            TicketButton.IsEnabled = true;
        }
    }
}
