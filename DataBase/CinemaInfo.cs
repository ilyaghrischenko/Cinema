using DataBase.DbModels;
using Microsoft.EntityFrameworkCore;
using static System.Console;

namespace DataBase
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
                     .Include("Hall")
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

        public static async Task<List<Customer>> GetCustomersAsync()
        {
            try
            {
                using (CinemaContext db = new())
                {
                    return await db.Customers.ToListAsync();
                }
            }
            catch
            {
                return new();
            }
        }
        public static async Task<List<Hall>> GetHallsAsync()
        {
            try
            {
                using (CinemaContext db = new())
                {
                    return await db.Halls.ToListAsync();
                }
            }
            catch
            {
                return new();
            }
        }
        public static async Task<List<Movie>> GetMoviesAsync()
        {
            try
            {
                using (CinemaContext db = new())
                {
                    return await db.Movies.ToListAsync();
                }
            }
            catch
            {
                return new();
            }
        }
        public static async Task<List<Session>> GetSessionsAsync()
        {
            try
            {
                using (CinemaContext db = new())
                {
                    return await db.Sessions.Include("Movie").Include("Hall").ToListAsync();
                }
            }
            catch
            {
                return new();
            }
        }
        public static async Task<List<Ticket>> GetTicketsAsync()
        {
            try
            {
                using (CinemaContext db = new())
                {
                    return await db.Tickets.Include("Session").Include("Session.Hall").Include("Session.Movie").Include("Customer").ToListAsync();
                }
            }
            catch
            {
                return new();
            }
        }
    }
}
