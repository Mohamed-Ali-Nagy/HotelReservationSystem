using Microsoft.AspNetCore.Identity;

namespace HotelReservationSystem.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Fullname { get; set; }
    }
}
