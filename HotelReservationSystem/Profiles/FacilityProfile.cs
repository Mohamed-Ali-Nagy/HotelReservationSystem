using AutoMapper;
using HotelReservationSystem.DTO.FacilityDTOs;
using HotelReservationSystem.Models;
using HotelReservationSystem.ViewModels.FacilityViewModels;

namespace HotelReservationSystem.Profiles
{
    public class FacilityProfile:Profile
    {
        public FacilityProfile()
        {
            CreateMap<Facility,FacilityDTO>().ReverseMap();
            CreateMap<FacilityVM,FacilityDTO>().ReverseMap();
            CreateMap<FacilityUpdateVM,FacilityUpdateDTO>().ReverseMap();
            CreateMap<FacilityUpdateDTO,Facility>().ReverseMap();

        }
    }
}
