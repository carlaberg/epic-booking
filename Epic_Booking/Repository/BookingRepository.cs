using Epic_Booking.Data;
using Epic_Booking.Models;
using Epic_Booking.Repository.IBookingRepostiory;
using Microsoft.EntityFrameworkCore;

namespace Epic_Booking.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<Booking> dbSet;
        public BookingRepository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<Booking>();
        }

        public async Task CreateAsync(Booking booking)
        {
            await dbSet.AddAsync(booking);
            await SaveAsync();
        }

        public async Task<Booking> UpdateAsync(Booking entity)
        {

            _db.Bookings.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public async Task<Booking> GetByIdAsync(int id)
        {
            return await _db.Bookings.FirstOrDefaultAsync(booking => booking.Id == id);
        }
        public async Task<List<Booking>> GetAllAsync()
        {
            return await _db.Bookings.ToListAsync();
        }

        public async Task DeleteAsync(Booking entity)
        {
            _db.Bookings.Remove(entity);
            await SaveAsync();
        }
    }
}
