using AutoMapper;
using HotelReservationSystem.DTO.Room;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.Profiles
{
    public class RoomProfile:Profile
    {
        public RoomProfile()
        {
            CreateMap<RoomCreateViewModel, RoomCreateDTO>().ReverseMap();
            CreateMap<Room, RoomCreateDTO>().ReverseMap();
            CreateMap<RoomEditViewModel, RoomEditDTO>().ReverseMap();
            CreateMap<Room, RoomEditDTO>().ReverseMap();

        }
    }
}
