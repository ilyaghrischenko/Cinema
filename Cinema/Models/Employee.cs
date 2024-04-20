using Microsoft.EntityFrameworkCore.Query;
using static System.Console;

namespace Cinema.Models
{
    public class Employee
    {
        public string FirstName { get; set; } = "NoFirstName";
        public string LastName { get; set; } = "NoLastName";
        public uint Age { get; set; } = 0;
        public string Email { get; set; } = "NoEmail";
        public string PhoneNumber { get; set; } = "NoPhoneNumber";

        public Employee() { }
        public Employee(string firstName, string lastName, uint age, string email, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public void RemoveCustomer()
        {
            CinemaInfo.ShowAllCustomers();
            Write("Enter the id of the customer you want to remove: ");
            if (!int.TryParse(ReadLine(), out int id)) throw new Exception("Invalid id input");

            using (CinemaContext db = new())
            {
                var customer = db.Customers.SingleOrDefault(x => x.Id == id);
                if (customer == null) throw new Exception("Customer not found");
                db.Customers.Remove(customer);
                db.SaveChanges();
            }
            WriteLine("You have successfully removed the customer");
            ReadKey();
        }
        public void RemoveHall()
        {
            CinemaInfo.ShowAllHalls();
            Write("Enter the id of the hall you want to remove: ");
            if (!int.TryParse(ReadLine(), out int id)) throw new Exception("Invalid id input");

            using (CinemaContext db = new())
            {
                var hall = db.Halls.SingleOrDefault(x => x.Id == id);
                if (hall == null) throw new Exception("Hall not found");
                db.Halls.Remove(hall);
                db.SaveChanges();
            }
            WriteLine("You have successfully removed the hall");
            ReadKey();
        }
        public void RemoveMovie()
        {
            CinemaInfo.ShowAllMovies();
            Write("Enter the id of the movie you want to remove: ");
            if (!int.TryParse(ReadLine(), out int id)) throw new Exception("Invalid id input");

            using (CinemaContext db = new())
            {
                var movie = db.Movies.SingleOrDefault(x => x.Id == id);
                if (movie == null) throw new Exception("Movie not found");
                db.Movies.Remove(movie);
                db.SaveChanges();
            }
            WriteLine("You have successfully removed the movie");
            ReadKey();
        }
        public void RemoveSession()
        {
            CinemaInfo.ShowAllSessions();
            Write("Enter the id of the session you want to remove: ");
            if (!int.TryParse(ReadLine(), out int id)) throw new Exception("Invalid id input");

            using (CinemaContext db = new())
            {
                var session = db.Sessions.SingleOrDefault(x => x.Id == id);
                if (session == null) throw new Exception("Session not found");
                db.Sessions.Remove(session);
                db.SaveChanges();
            }
            WriteLine("You have successfully removed the session");
            ReadKey();
        }
        public void RemoveTicket()
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
            ReadKey();
        }

        public void AddHall()
        {
            Write("Enter number: ");
            if (!uint.TryParse(ReadLine(), out uint number)) throw new Exception("Invalid number input");
            Write("Enter capacity: ");
            if (!uint.TryParse(ReadLine(), out uint capacity)) throw new Exception("Invalid capacity input");

            Hall hall = new(number, capacity);

        }
    }
}
