using AutoMapper;
using Epic_Booking.Models;
using Epic_Booking.Models.Dto;

namespace Epic_Booking
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Booking, BookingDTO>();
            CreateMap<BookingDTO, Booking>();
            
            CreateMap<Booking, BookingCreateDTO>().ReverseMap();
            CreateMap<Booking, BookingUpdateDTO>().ReverseMap();
        }
    }
}