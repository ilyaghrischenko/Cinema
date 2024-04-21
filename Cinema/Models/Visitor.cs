using static System.Console;

namespace Cinema.Models
{
    public class Visitor : Customer
    {
        public Visitor() { }
        public Visitor(string firstName, string lastName, string email, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
        }
        
        public void BookSession()
        {
            using (CinemaContext db = new())
            {
                CinemaInfo.ShowAllSessions();
                Write("Enter the ID of the session for which you wish to book: ");
                if (!int.TryParse(ReadLine(), out int sessionId)) throw new Exception("Invalid id input");

                Write("Enter seat number: ");
                if (!uint.TryParse(ReadLine(), out uint seatNumber)) throw new Exception("Invalid seat number input");

                var session = db.Sessions.FirstOrDefault(x => x.Id == sessionId) ?? throw new Exception("Session not found");
                if (db.Tickets.SingleOrDefault(x => x.SeatNumber == seatNumber && x.Session == session) != null) throw new Exception("This seat for this session is already taken");

                var customer = db.Customers
                         .SingleOrDefault(x => x.FirstName == FirstName
                         && x.LastName == LastName
                         && x.Email == Email
                         && x.PhoneNumber == PhoneNumber);
                if (customer == null) db.Customers.Add(this);

                Ticket ticket = new(session, seatNumber, customer ?? this, DateTime.Now);
                db.Tickets.Add(ticket);

                db.SaveChanges();
                WriteLine("You have successfully booked a ticket");
            }
        }

    }
}
