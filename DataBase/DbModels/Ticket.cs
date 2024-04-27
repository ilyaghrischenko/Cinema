namespace DataBase.DbModels
{
    public class Ticket
    {
        public int Id { get; set; }
        public Session Session { get; set; }
        public uint SeatNumber { get; set; }
        public Customer Customer { get; set; }
        public DateTime PurchasedDate { get; set; }

        public Ticket() { }
        public Ticket(Session session, uint seatNumber, Customer customer, DateTime purchasedDate)
        {
            Session = session;
            SeatNumber = seatNumber;
            Customer = customer;
            PurchasedDate = purchasedDate;
        }

        public override string ToString()
        {
            return $"Session: {Session}\nSeat number: {SeatNumber}, Customer: {Customer.FirstName} {Customer.LastName}, Purchased date: {PurchasedDate}";
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || obj is not Ticket) return false;
            var other = obj as Ticket;
            return ToString() == other?.ToString();
        }
    }
}
