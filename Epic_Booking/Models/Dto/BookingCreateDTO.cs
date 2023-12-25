using System.ComponentModel.DataAnnotations;

namespace Epic_Booking.Models.Dto
{
    public class BookingCreateDTO
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime Start { get; set; }
        [Required]
        public DateTime End { get; set; }
    }
}