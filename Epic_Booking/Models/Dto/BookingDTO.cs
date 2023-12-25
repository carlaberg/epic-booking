using System.ComponentModel.DataAnnotations;

namespace Epic_Booking.Models
{
	public class BookingDTO
	{
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime Start { get; set; }
        [Required]
        public DateTime End { get; set; }
    }
}

