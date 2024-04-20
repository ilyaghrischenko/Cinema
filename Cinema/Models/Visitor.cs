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
                db.Customers.Add(this);

                CinemaInfo.ShowAllSessions();
                Write("Enter the ID of the session for which you wish to book: ");
                if (!int.TryParse(ReadLine(), out int sessionId)) throw new Exception("Invalid id input");
                Write("Enter seat number: ");
                if (!uint.TryParse(ReadLine(), out uint seatNumber)) throw new Exception("Invalid seat number input");

                var session = db.Sessions.FirstOrDefault(x => x.Id == sessionId);
                if (session == null) throw new Exception("Session not found");

                Ticket ticket = new(session, seatNumber, this, DateTime.Now);

                db.Tickets.Add(ticket);
                WriteLine("You have successfully booked a ticket");
                db.SaveChanges();
                ReadKey();
            }
        }

    }
}
