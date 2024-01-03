using Epic_Booking.Models;
using Epic_Booking.Models.Dto;

namespace Epic_Booking.Repository.IRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string username);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<RegisterResponseDTO> Register(RegisterationRequestDTO registerationRequestDTO);
    }
}
