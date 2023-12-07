using Epic_Booking.Models;
using Microsoft.EntityFrameworkCore;

namespace Epic_Booking.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Booking>().HasData(
                new Booking { Id = 123, Title = "Booking 1", Start = DateTime.Now, End = DateTime.Now.AddHours(2) },
                new Booking { Id = 456, Title = "Booking 2", Start = DateTime.Now.AddDays(1), End = DateTime.Now.AddDays(1).AddHours(2) }
            );
        }        
    }
}
