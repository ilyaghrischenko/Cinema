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
            GetSessionsAsync();
        }

        private async void GetSessionsAsync()
        => SessionsList.ItemsSource = await CinemaInfo.GetSessionsAsync();

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
                MovieInput.Clear();
                TicketButton.IsEnabled = true;
                return;
            }

            var halls = await CinemaInfo.GetHallsAsync();
            if (!uint.TryParse(HallInput.Text, out uint hallNumber))
            {
                MessageBox.Show("Invalid hall number input");
                HallInput.Clear();
                TicketButton.IsEnabled = true;
                return;
            }
            var hall = halls.SingleOrDefault(x => x.Number == hallNumber);
            if (hall == null)
            {
                MessageBox.Show("Hall with this number does not exist");
                HallInput.Clear();
                TicketButton.IsEnabled = true;
                return;
            }

            var sessions = await CinemaInfo.GetSessionsAsync();
            if (!DateTime.TryParse(StartTimeInput.Text, out DateTime startTime))
            {
                MessageBox.Show("Invalid start time input");
                StartTimeInput.Clear();
                TicketButton.IsEnabled = true;
                return;
            }
            var session = sessions.SingleOrDefault(x => x.StartTime == startTime && x.Movie.Equals(movie) && x.Hall.Equals(hall));
            if (session == null)
            {
                MessageBox.Show("Session with this movie, hall and start time does not exist");
                MovieInput.Clear();
                HallInput.Clear();
                StartTimeInput.Clear();
                SeatNumberInput.Clear();
                TicketButton.IsEnabled = true;
                return;
            }

            var tickets = await CinemaInfo.GetTicketsAsync();
            if (!uint.TryParse(SeatNumberInput.Text, out uint seatNumber))
            {
                MessageBox.Show("Invalid seat number input");
                SeatNumberInput.Clear();
                TicketButton.IsEnabled = true;
                return;
            }
            var ticket = tickets.SingleOrDefault(x => x.SeatNumber == seatNumber && x.Session.Equals(session));
            if (ticket != null)
            {
                MessageBox.Show("Ticket with this seat number on this session already exist");
                SeatNumberInput.Clear();
                TicketButton.IsEnabled = true;
                return;
            }

            using CinemaContext db = new();
            Ticket newTicket = new(db.Sessions.First(x => x.Equals(session)), seatNumber, db.Customers.First(x => x.Equals(Customer)), DateTime.Now);
            db.Tickets.Add(newTicket);
            db.SaveChanges();

            MessageBox.Show("You have successfully purchased a ticket");
            TicketButton.IsEnabled = true;
        }
    }
}
