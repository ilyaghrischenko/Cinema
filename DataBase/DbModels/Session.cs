namespace DataBase.DbModels
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
            return $"Movie: {Movie.Title}, Hall: {Hall.Number}, Start time: {StartTime}, Price: {Price}";
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || obj is not Session) return false;
            var other = obj as Session;
            return ToString() == other?.ToString();
        }
    }
}
