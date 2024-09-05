using System.ComponentModel.DataAnnotations;

namespace HotelReservationSystem.ViewModels.UserVMs
{
    public class UserLoginVM
    {
        [Required]
        public string UserName { get; set; }
        [Required]

        public string Password { get; set; }
    }
}
