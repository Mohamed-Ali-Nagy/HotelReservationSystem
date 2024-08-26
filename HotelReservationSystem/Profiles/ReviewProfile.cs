using AutoMapper;
using HotelReservationSystem.DTO.Review;
using HotelReservationSystem.Models;
using HotelReservationSystem.ViewModels.Review;

namespace HotelReservationSystem.Profiles
{
    public class ReviewProfile:Profile
    {
        public ReviewProfile()
        {
            CreateMap<ReviewViewModel,ReviewDTO>().ReverseMap();
            CreateMap<ReviewDTO, Review>().ReverseMap();
        }
    }
}
