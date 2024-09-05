using HotelReservationSystem.DTO.UserDTOs;

namespace HotelReservationSystem.Services.UserServices
{
    public interface IUserService
    {
        public bool Authenticated(UserLoginDTO userLoginDTO);
        public string GenerateToken(UserLoginDTO userLoginDTO);
    }
}
