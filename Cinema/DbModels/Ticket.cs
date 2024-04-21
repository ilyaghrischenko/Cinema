namespace Cinema.Models
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
            return $"Id: {Id}\nSession: {Session}\nSeat number: {SeatNumber}\nCustomer: {Customer}\nPurchased date: {PurchasedDate}";
        }
    }
}
