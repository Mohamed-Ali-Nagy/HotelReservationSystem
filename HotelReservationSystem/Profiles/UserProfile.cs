using AutoMapper;
using HotelReservationSystem.DTO.UserDTOs;
using HotelReservationSystem.Models;
using HotelReservationSystem.ViewModels.UserVMs;

namespace HotelReservationSystem.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<UserRegistreVM, UserLoginDTO>();
            CreateMap<UserRegisterVM, UserRegisterDTO>();
            CreateMap<UserRegisterDTO,User>().ReverseMap();
        }
    }
}
