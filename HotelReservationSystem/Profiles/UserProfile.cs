using AutoMapper;
using HotelReservationSystem.DTO.UserDTOs;
using HotelReservationSystem.ViewModels.UserVMs;

namespace HotelReservationSystem.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<UserLoginVM, UserLoginDTO>();
        }
    }
}
