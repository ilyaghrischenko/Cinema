using DataBase;
using DataBase.DbModels;
using System.Windows;

namespace CinemaWPF
{
    public partial class AddSessionWindow : Window
    {
        public AddSessionWindow()
        {
            InitializeComponent();
            GetInfoAsync();
        }

        private async void GetInfoAsync()
        {
            MoviesList.ItemsSource = await CinemaInfo.GetMoviesAsync();
            HallsList.ItemsSource = await CinemaInfo.GetHallsAsync();
        }

        private async void Add(object sender, RoutedEventArgs e)
        {
            if (MoviesList.SelectedItem == null || HallsList.SelectedItem == null)
            {
                MessageBox.Show("You didn't pick the hall or the movie");
                return;
            }
            var movie = MoviesList.SelectedItem as Movie;
            var hall = HallsList.SelectedItem as Hall;

            if (string.IsNullOrEmpty(StartTimeInput.Text)
                || string.IsNullOrEmpty(PriceInput.Text))
            {
                MessageBox.Show("You have not filled all fields");
                return;
            }

            if (!DateTime.TryParse(StartTimeInput.Text, out var startTime))
            {
                MessageBox.Show("Invalid value for startTime");
                StartTimeInput.Clear();
                return;
            }
            var sessions = await CinemaInfo.GetSessionsAsync();
            if (sessions.SingleOrDefault(x => x.StartTime == startTime && x.Hall.Number == hall.Number) != null)
            {
                MessageBox.Show("Session with this start time already exist");
                StartTimeInput.Clear();
                return;
            }

            if (!decimal.TryParse(PriceInput.Text, out var price))
            {
                MessageBox.Show("Invalid value for price");
                PriceInput.Clear();
                return;
            }

            using (CinemaContext db = new())
            {
                Session newSession = new(db.Movies.First(x => x.Equals(movie)), db.Halls.First(x => x.Equals(hall)), startTime, price);
                var findedSession = sessions.SingleOrDefault(x => x.Equals(newSession));
                if (findedSession != null)
                {
                    MessageBox.Show("This session already exist");
                    StartTimeInput.Clear();
                    PriceInput.Clear();
                    return;
                }
                db.Sessions.Add(newSession);
                db.SaveChanges();
                MessageBox.Show("New session successfully added");
            }
        }
    }
}
