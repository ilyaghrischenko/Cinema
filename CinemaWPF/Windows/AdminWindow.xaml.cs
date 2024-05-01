using DataBase;
using DataBase.DbModels;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms.VisualStyles;

namespace CinemaWPF
{
    public partial class AdminWindow : Window
    {
        private Button LastButtonClicked { get; set; }

        public AdminWindow()
        {
            InitializeComponent();
            AddButton.IsEnabled = false;
        }

        private async void ShowCustomers(object sender, RoutedEventArgs e)
        {
            LastButtonClicked?.ClearValue(BackgroundProperty);
            LastButtonClicked = ShowCustomersButton;
            LastButtonClicked.Background = System.Windows.Media.Brushes.Gold;
            DataList.ItemsSource = await CinemaInfo.GetCustomersAsync();
        }
        private async void ShowHalls(object sender, RoutedEventArgs e)
        {
            AddButton.IsEnabled = true;
            LastButtonClicked?.ClearValue(BackgroundProperty);
            LastButtonClicked = ShowHallsButton;
            LastButtonClicked.Background = System.Windows.Media.Brushes.Gold;
            DataList.ItemsSource = await CinemaInfo.GetHallsAsync();
        }
        private async void ShowMovies(object sender, RoutedEventArgs e)
        {
            AddButton.IsEnabled = true;
            LastButtonClicked?.ClearValue(BackgroundProperty);
            LastButtonClicked = ShowMoviesButton;
            LastButtonClicked.Background = System.Windows.Media.Brushes.Gold;
            DataList.ItemsSource = await CinemaInfo.GetMoviesAsync();
        }
        private async void ShowSessions(object sender, RoutedEventArgs e)
        {
            AddButton.IsEnabled = true;
            LastButtonClicked?.ClearValue(BackgroundProperty);
            LastButtonClicked = ShowSessionsButton;
            LastButtonClicked.Background = System.Windows.Media.Brushes.Gold;
            DataList.ItemsSource = await CinemaInfo.GetSessionsAsync();
        }
        private async void ShowTickets(object sender, RoutedEventArgs e)
        {
            LastButtonClicked?.ClearValue(BackgroundProperty);
            LastButtonClicked = ShowTicketsButton;
            LastButtonClicked.Background = System.Windows.Media.Brushes.Gold;
            DataList.ItemsSource = await CinemaInfo.GetTicketsAsync();
        }

        private async void Add(object sender, RoutedEventArgs e)
        {
            Window? window = null;
            if (LastButtonClicked == ShowHallsButton) window = new AddHallWindow();
            else if (LastButtonClicked == ShowMoviesButton) window = new AddMovieWindow();
            //else if (LastButtonClicked == ShowSessionsButton) window = new AddSessionWindow();
            window?.ShowDialog();
        }
        private async void Remove(object sender, RoutedEventArgs e)
        {
            if (DataList.Items.Count == 0)
            {
                MessageBox.Show("Nothing to delete");
                return;
            }
            if (DataList.SelectedItem == null)
            {
                MessageBox.Show("You haven't selected a deletion target");
                return;
            }

            using (CinemaContext db = new())
            {
                if (LastButtonClicked == ShowCustomersButton)
                {
                    var selectedObject = DataList.SelectedItem as Customer;
                    db.Customers.Remove(selectedObject);
                }
                else if (LastButtonClicked == ShowHallsButton)
                {
                    var selectedObject = DataList.SelectedItem as Hall;
                    db.Halls.Remove(selectedObject);
                }
                else if (LastButtonClicked == ShowMoviesButton)
                {
                    var selectedObject = DataList.SelectedItem as Movie;
                    db.Movies.Remove(selectedObject);
                }
                else if (LastButtonClicked == ShowSessionsButton)
                {
                    var selectedObject = DataList.SelectedItem as Session;
                    db.Sessions.Remove(selectedObject);
                }
                else if (LastButtonClicked == ShowTicketsButton)
                {
                    var selectedObject = DataList.SelectedItem as Ticket;
                    db.Tickets.Remove(selectedObject);
                }
                db.SaveChanges();
            }
            MessageBox.Show("Object successfully deleted");
        }
    }
}
