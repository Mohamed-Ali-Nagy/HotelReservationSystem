using System.ComponentModel.DataAnnotations;

namespace HotelReservationSystem.ViewModels.UserVMs
{
    public class UserRegistreVM
    {
        [Required]
        public string UserName { get; set; }
        [Required]

        public string Password { get; set; }
    }
}
