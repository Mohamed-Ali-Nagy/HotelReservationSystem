using AutoMapper;
using HotelReservationSystem.DTO.Room;
using HotelReservationSystem.Models;
using HotelReservationSystem.ViewModels.Room;

namespace HotelReservationSystem.Profiles
{
    public class RoomProfile:Profile
    {
        public RoomProfile()
        {
            CreateMap<RoomCreateVM, RoomCreateDTO>().ReverseMap();
            CreateMap<Room, RoomCreateDTO>().ReverseMap();
            CreateMap<Room, RoomResponseDTO>().ReverseMap();
            CreateMap<RoomResponseDTO,RoomResponseVM>();
            CreateMap<RoomPicturesDTO, RoomPicturesVM>().ReverseMap();
            CreateMap<RoomUpdateVM, RoomUpdateDTO>();
            CreateMap<RoomUpdateDTO,Room>();
            
            
            CreateMap<Room, RoomGetDTO>().ReverseMap();
            CreateMap<RoomGetViewModel, RoomGetDTO>().ReverseMap();
        }
    }
}
