namespace Cinema.Models
{
    public class Session
    {
        public int Id { get; set; }
        public Movie Movie { get; set; }
        public Hall Hall { get; set; }
        public DateTime StartTime { get; set; }
        public decimal Price { get; set; }

        public Session() { }
        public Session(Movie movie, Hall hall, DateTime startTime, decimal price)
        {
            Movie = movie;
            Hall = hall;
            StartTime = startTime;
            Price = price;
        }

        public override string ToString()
        {
            return $"Id: {Id}\nMovie: {Movie}\nHall: {Hall}\nStart time: {StartTime}, Price: {Price}";
        }
    }
}
