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
            Write("Enter first name: ");
            FirstName = ReadLine() ?? throw new Exception("Invalid first name input");
            Write("Enter last name: ");
            LastName = ReadLine() ?? throw new Exception("Invalid last name input");
            Write("Email: ");
            Email = ReadLine() ?? throw new Exception("Invalid email input");
            Write("Phone number: ");
            PhoneNumber = ReadLine() ?? throw new Exception("Invalid phone number input");

            using (CinemaContext db = new())
            {
                db.Customers.Add(this);

                CinemaInfo.ShowAllSessions();
                Write("Enter the ID of the session for which you wish to book: ");
                if (!int.TryParse(ReadLine(), out int sessionId)) throw new Exception("Invalid id input");

                Write("Enter seat number: ");
                if (!uint.TryParse(ReadLine(), out uint seatNumber)) throw new Exception("Invalid seat number input");

                var session = db.Sessions.FirstOrDefault(x => x.Id == sessionId);
                if (session == null) throw new Exception("Session not found");
                if (db.Tickets.SingleOrDefault(x => x.SeatNumber == seatNumber && x.Session == session) != null) throw new Exception("This seat for this session is already taken");

                Ticket ticket = new(session, seatNumber, this, DateTime.Now);
                db.Tickets.Add(ticket);

                db.SaveChanges();
                WriteLine("You have successfully booked a ticket");
            }
        }

    }
}
