using AutoMapper;
using HotelReservationSystem.DTO.Payment;
using HotelReservationSystem.DTO.Review;
using HotelReservationSystem.Models;
using HotelReservationSystem.ViewModels.Payment;
using HotelReservationSystem.ViewModels.Review;

namespace HotelReservationSystem.Profiles
{
    public class PaymentProfile:Profile
    {
        public PaymentProfile()
        {
            CreateMap<PaymentCreateVM,PaymentCreateDTO>().ReverseMap();
            CreateMap<PaymentCreateDTO, Payment>().ReverseMap();

            CreateMap<PaymentEditVM, PaymentEditDTO>().ReverseMap();
            CreateMap<PaymentEditDTO, Payment>().ReverseMap();


            CreateMap<PaymentGetVM, PaymentGetDTO>().ReverseMap();
            CreateMap<PaymentGetDTO, Payment>().ReverseMap();
        }
    }
}
