using Microsoft.AspNetCore.Identity;

namespace Epic_Booking.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
