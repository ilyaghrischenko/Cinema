using Microsoft.EntityFrameworkCore;
using static System.Console;

namespace Cinema
{
    public static class CinemaInfo
    {
        public static void ShowAllCustomers()
        {
            WriteLine("Customers:");
            using (CinemaContext db = new())
            {
                db.Customers
                      .ToList()
                      .ForEach(WriteLine);
            }
        }
        public static void ShowAllHalls()
        {
            WriteLine("Halls:");
            using (CinemaContext db = new())
            {
                db.Halls
                    .ToList()
                    .ForEach(WriteLine);
            }
        }
        public static void ShowAllMovies()
        {
            WriteLine("Movies:");
            using (CinemaContext db = new())
            {
                db.Movies
                     .ToList()
                     .ForEach(WriteLine);
            }
        }
        public static void ShowAllSessions()
        {
            WriteLine("Sessions:");
            using (CinemaContext db = new())
            {
                db.Sessions
                     .Include("Movie")
                     .ToList()
                     .ForEach(WriteLine);
            }
        }
        public static void ShowAllTickets()
        {
            WriteLine("Tickets:");
            using (CinemaContext db = new())
            {
                db.Tickets
                     .Include("Session.Movie")
                     .Include("Session.Hall")
                     .Include("Customer")
                     .ToList()
                     .ForEach(WriteLine);
            }
        }
    }
}
