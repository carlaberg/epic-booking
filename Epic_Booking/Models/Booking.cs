using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Epic_Booking.Models
{
	public class Booking
	{
        [Required]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}

