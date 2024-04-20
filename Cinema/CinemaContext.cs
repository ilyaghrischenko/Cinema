using Cinema.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema
{
    public class CinemaContext : DbContext
    {
        public CinemaContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer
            ("data source=(localdb)\\MSSQLLocalDB;initial catalog=Cinema;integrated security=True;MultipleActiveResultSets=true");

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}
