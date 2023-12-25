using Epic_Booking.Models;

namespace Epic_Booking.Repository.IBookingRepostiory
{
    public interface IBookingRepository
    {
        Task CreateAsync(Booking booking);
        Task SaveAsync();
        Task<Booking> GetByIdAsync(int id);
        Task<List<Booking>> GetAllAsync();
        Task<Booking> UpdateAsync(Booking entity);
        Task DeleteAsync(Booking entity);
    }
}
