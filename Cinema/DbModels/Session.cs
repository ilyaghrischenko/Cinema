using static System.Console;

namespace Cinema.Models
{
    public class Session
    {
        public int Id { get; set; }
        public Movie Movie { get; set; }
        public Hall Hall { get; set; }
        public DateTime StartTime { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}\nMovie: {Movie}\nHall: {Hall}\nStart time: {StartTime}, Price: {Price}";
        }
    }
}
