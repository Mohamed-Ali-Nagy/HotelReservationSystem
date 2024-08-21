using AutoMapper;
using HotelReservationSystem.DTO.Room;
using HotelReservationSystem.DTO.RoomFacilitiesDTOs;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.Profiles
{
    public class RoomFacilitiesProfile:Profile
    {
        public RoomFacilitiesProfile()
        {
            CreateMap<RoomCreateDTO, RoomFacilities>();
            CreateMap<RoomFacilities,RoomFacilityResponseDTO>();

        }
    }
}
