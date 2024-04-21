using static System.Console;

namespace Cinema.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public float Duration { get; set; }
        public DateOnly ReleaseDate { get; set; }

        public Movie() { }
        public Movie(string title, string director, string genre, float duration, DateOnly releaseDate)
        {
            Title = title;
            Director = director;
            Genre = genre;
            Duration = duration;
            ReleaseDate = releaseDate;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Title: {Title}, Director: {Director}, Genre: {Genre}, Duration: {Duration}, Release date: {ReleaseDate}";
        }
    }
}
