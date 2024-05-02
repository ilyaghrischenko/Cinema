using DataBase;
using DataBase.DbModels;
using System.Windows;

namespace CinemaWPF
{
    public partial class AddHallWindow : Window
    {
        public AddHallWindow()
        {
            InitializeComponent();
        }

        private async void Add(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NumberInput.Text)
                || string.IsNullOrEmpty(CapacityInput.Text))
            {
                MessageBox.Show("You have not filled all fields");
                return;
            }

            if (!uint.TryParse(NumberInput.Text, out uint number))
            {
                MessageBox.Show("Invalid number input");
                NumberInput.Clear();
                return;
            }
            if (!uint.TryParse(CapacityInput.Text, out uint capacity))
            {
                MessageBox.Show("Invalid capacity input");
                CapacityInput.Clear();
                return;
            }

            var halls = await CinemaInfo.GetHallsAsync();
            if (halls.SingleOrDefault(x => x.Number == number) != null)
            {
                MessageBox.Show("Hall with this number already exist");
                NumberInput.Clear();
                return;
            }

            Hall newHall = new(number, capacity);
            var findedHall = halls.SingleOrDefault(x => x.Equals(newHall));
            if (findedHall != null)
            {
                MessageBox.Show("This hall already exist");
                NumberInput.Clear();
                CapacityInput.Clear();
                return;
            }

            using (CinemaContext db = new())
            {
                db.Halls.Add(newHall);
                db.SaveChanges();
            }
            MessageBox.Show("New hall successfully added");
        }
    }
}
