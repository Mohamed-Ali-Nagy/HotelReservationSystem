using AutoMapper;
using HotelReservationSystem.DTO.Reservation;
using HotelReservationSystem.Models;
using HotelReservationSystem.ViewModels.Reservation;

namespace HotelReservationSystem.Profiles
{
    public class ReservationProfile : Profile
    {

        public ReservationProfile() 
        {

            CreateMap<ReservationViewModel, ReservationDTO>().ReverseMap();

            CreateMap<ReservationDTO, Reservation>().ReverseMap();
        }
    }
}
