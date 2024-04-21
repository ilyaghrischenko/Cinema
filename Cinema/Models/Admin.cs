using static System.Console;

namespace Cinema.Models
{
    public static class Admin
    {
        public static void RemoveCustomer()
        {
            CinemaInfo.ShowAllCustomers();
            Write("Enter the id of the customer you want to remove: ");
            if (!int.TryParse(ReadLine(), out int id)) throw new Exception("Invalid id input");

            using (CinemaContext db = new())
            {
                var customer = db.Customers.SingleOrDefault(x => x.Id == id);
                if (customer == null) throw new Exception("Customer not found");

                db.Customers.Remove(customer);
                var ticket = db.Tickets.SingleOrDefault(x => x.Customer == customer);
                if (ticket != null) db.Tickets.Remove(ticket);

                db.SaveChanges();
            }
            WriteLine("You have successfully removed the customer");
        }
        public static void RemoveHall()
        {
            CinemaInfo.ShowAllHalls();
            Write("Enter the id of the hall you want to remove: ");
            if (!int.TryParse(ReadLine(), out int id)) throw new Exception("Invalid id input");

            using (CinemaContext db = new())
            {
                var hall = db.Halls.SingleOrDefault(x => x.Id == id);
                if (hall == null) throw new Exception("Hall not found");

                db.Halls.Remove(hall);
                var session = db.Sessions.SingleOrDefault(x => x.Hall == hall);
                if (session != null) db.Sessions.Remove(session);
                
                db.SaveChanges();
            }
            WriteLine("You have successfully removed the hall");
        }
        public static void RemoveMovie()
        {
            CinemaInfo.ShowAllMovies();
            Write("Enter the id of the movie you want to remove: ");
            if (!int.TryParse(ReadLine(), out int id)) throw new Exception("Invalid id input");

            using (CinemaContext db = new())
            {
                var movie = db.Movies.SingleOrDefault(x => x.Id == id);
                if (movie == null) throw new Exception("Movie not found");

                db.Movies.Remove(movie);
                var session = db.Sessions.SingleOrDefault(x => x.Movie == movie);
                if (session != null) db.Sessions.Remove(session);

                db.SaveChanges();
            }
            WriteLine("You have successfully removed the movie");
        }
        public static void RemoveSession()
        {
            CinemaInfo.ShowAllSessions();
            Write("Enter the id of the session you want to remove: ");
            if (!int.TryParse(ReadLine(), out int id)) throw new Exception("Invalid id input");

            using (CinemaContext db = new())
            {
                var session = db.Sessions.SingleOrDefault(x => x.Id == id);
                if (session == null) throw new Exception("Session not found");

                db.Sessions.Remove(session);
                var ticket = db.Tickets.SingleOrDefault(x => x.Session == session);
                if (ticket != null) db.Tickets.Remove(ticket);

                db.SaveChanges();
            }
            WriteLine("You have successfully removed the session");
        }
        public static void RemoveTicket()
        {
            CinemaInfo.ShowAllTickets();
            Write("Enter the id of the ticket you want to remove: ");
            if (!int.TryParse(ReadLine(), out int id)) throw new Exception("Invalid id input");

            using (CinemaContext db = new())
            {
                var ticket = db.Tickets.SingleOrDefault(x => x.Id == id);
                if (ticket == null) throw new Exception("Ticket not found");
                db.Tickets.Remove(ticket);
                db.SaveChanges();
            }
            WriteLine("You have successfully removed the ticket");
        }

        public static void AddHall()
        {
            using (CinemaContext db = new())
            {
                Write("Enter number: ");
                if (!uint.TryParse(ReadLine(), out uint number)) throw new Exception("Invalid number input");
                if (db.Halls.SingleOrDefault(x => x.Number == number) != null) throw new Exception("A hall with that number already exists");

                Write("Enter capacity: ");
                if (!uint.TryParse(ReadLine(), out uint capacity)) throw new Exception("Invalid capacity input");

                Hall hall = new(number, capacity);
                db.Halls.Add(hall);

                db.SaveChanges();
                WriteLine("You have successfully added a new hall");
            }
        }
        public static void AddMovie()
        {
            using (CinemaContext db = new())
            {
                Write("Enter title: ");
                string title = ReadLine() ?? throw new Exception("Invalid title input");
                Write("Enter director: ");
                string director = ReadLine() ?? throw new Exception("Invalid director input");
                Write("Enter genre: ");
                string genre = ReadLine() ?? throw new Exception("Invalid genre input");
                Write("Enter duration: ");
                if (!float.TryParse(ReadLine(), out float duration)) throw new Exception("Invalid duration input");
                Write("Enter release date: ");
                if (!DateOnly.TryParse(ReadLine(), out DateOnly releaseDate)) throw new Exception("Invalid release date input");

                Movie movie = new(title, director, genre, duration, releaseDate);
                if (db.Movies.Contains(movie)) throw new Exception("This movie already exist");
                db.Movies.Add(movie);

                db.SaveChanges();
                WriteLine("You have successfully added a new movie");
            }
        }
        public static void AddSession()
        {
            using (CinemaContext db = new())
            {
                CinemaInfo.ShowAllMovies();
                Write("Enter the id of the movie that will be in the session: ");
                if (!int.TryParse(ReadLine(), out int id)) throw new Exception("Invalid id input");
                var movie = db.Movies.SingleOrDefault(x => x.Id == id) ?? throw new Exception("Movie with this id does not exist");

                CinemaInfo.ShowAllHalls();
                Write("Enter the id of the hall that will be in the session: ");
                if (!int.TryParse(ReadLine(), out int idHall)) throw new Exception("Invalid id input");
                var hall = db.Halls.SingleOrDefault(x => x.Id == idHall) ?? throw new Exception("Hall with this id does not exist");

                Write("Enter start time: ");
                if (!DateTime.TryParse(ReadLine(), out DateTime startTime)) throw new Exception("Invalid start time input");

                Write("Enter price: ");
                if (!decimal.TryParse(ReadLine(), out decimal price)) throw new Exception("Invalid price input");

                Session session = new(movie, hall, startTime, price);
                if (db.Sessions.Contains(session)) throw new Exception("This session already exist");

                db.Sessions.Add(session);
                db.SaveChanges();
                WriteLine("You have successfully added a new session");
            }
        }
    }
}
