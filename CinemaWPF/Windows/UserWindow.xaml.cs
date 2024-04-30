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
                AddCustomer();
            }
            else
            {
                var findedCustomer = customers.SingleOrDefault(x => x.Equals(Customer));
                if (findedCustomer == null) AddCustomer();
                else Customer = findedCustomer;
            }

            var sessions = await CinemaInfo.GetSessionsAsync();
            var text = "";
            sessions.ForEach(x => text += $"{x}\n");
            SessionsList.Text = text;
        }
        private void AddCustomer()
        {
            using (CinemaContext db = new())
            {
                db.Customers.Add(Customer);
                db.SaveChanges();
            }
        }

        private async void TicketBuy(object sender, RoutedEventArgs e)
        {
            TicketButton.IsEnabled = false;

            if (string.IsNullOrEmpty(MovieInput.Text)
                || string.IsNullOrEmpty(HallInput.Text)
                || string.IsNullOrEmpty(StartTimeInput.Text)
                || string.IsNullOrEmpty(SeatNumberInput.Text))
            {
                MessageBox.Show("You have not filled all fields");
                TicketButton.IsEnabled = true;
                return;
            }

            var movies = await CinemaInfo.GetMoviesAsync();
            var movie = movies.SingleOrDefault(x => x.Title == MovieInput.Text);
            if (movie == null)
            {
                MessageBox.Show("Movie with this name does not exist");
                TicketButton.IsEnabled = true;
                return;
            }

            var halls = await CinemaInfo.GetHallsAsync();
            var hallNumber = uint.Parse(HallInput.Text);
            var hall = halls.SingleOrDefault(x => x.Number == hallNumber);
            if (hall == null)
            {
                MessageBox.Show("Hall with this number does not exist");
                TicketButton.IsEnabled = true;
                return;
            }

            var sessions = await CinemaInfo.GetSessionsAsync();
            var startTime = DateTime.Parse(StartTimeInput.Text);
            var session = sessions.SingleOrDefault(x => x.StartTime == startTime && x.Movie.Equals(movie) && x.Hall.Equals(hall));
            if (session == null)
            {
                MessageBox.Show("Session with this movie, hall and start time does not exist");
                TicketButton.IsEnabled = true;
                return;
            }

            var tickets = await CinemaInfo.GetTicketsAsync();
            var seatNumber = uint.Parse(SeatNumberInput.Text);
            var ticket = tickets.SingleOrDefault(x => x.SeatNumber == seatNumber && x.Session.Equals(session));
            if (ticket != null)
            {
                MessageBox.Show("Ticket with this seat number on this session already exist");
                TicketButton.IsEnabled = true;
                return;
            }

            Ticket newTicket = new(session, seatNumber, Customer, DateTime.Now);
            using (CinemaContext db = new())
            {
                db.Tickets.Add(newTicket);
                db.SaveChanges();
            }
            MessageBox.Show("You have successfully purchased a ticket");
            TicketButton.IsEnabled = true;
        }
    }
}
