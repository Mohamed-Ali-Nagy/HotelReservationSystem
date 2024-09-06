using HotelReservationSystem.Models;

namespace HotelReservationSystem.DTO.UserDTOs
{
    public class UserRegisterDTO
    {

        public string UserName { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
