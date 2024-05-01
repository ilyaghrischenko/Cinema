using DataBase;
using DataBase.DbModels;
using System.Windows;

namespace CinemaWPF
{
    public partial class AddMovieWindow : Window
    {
        public AddMovieWindow()
        {
            InitializeComponent();
        }

        private async void Add(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TitleInput.Text)
                || string.IsNullOrEmpty(DirectorInput.Text)
                || string.IsNullOrEmpty(GenreInput.Text)
                || string.IsNullOrEmpty(DurationInput.Text)
                || string.IsNullOrEmpty(ReleaseDateInput.Text))
            {
                MessageBox.Show("You have not filled all fields");
                return;
            }

            string title = TitleInput.Text;
            string director = DirectorInput.Text;
            string genre = GenreInput.Text;
            if (!float.TryParse(DurationInput.Text, out var duration))
            {
                MessageBox.Show("Invalid value for duration");
                DurationInput.Clear();
                return;
            }
            if (!DateOnly.TryParse(ReleaseDateInput.Text, out var releaseDate))
            {
                MessageBox.Show("Invalid value for release date");
                ReleaseDateInput.Clear();
                return;
            }

            var movies = await CinemaInfo.GetMoviesAsync();
            Movie newMovie = new(title, director, genre, duration, releaseDate);
            var findedMovie = movies.SingleOrDefault(x => x.Equals(newMovie));
            if (findedMovie != null)
            {
                MessageBox.Show("This movie already exist");
                TitleInput.Clear();
                DirectorInput.Clear();
                DurationInput.Clear();
                ReleaseDateInput.Clear();
                return;
            }

            using (CinemaContext db = new())
            {
                db.Movies.Add(newMovie);
                db.SaveChanges();
            }
            MessageBox.Show("New movie successfully added");
        }
    }
}
