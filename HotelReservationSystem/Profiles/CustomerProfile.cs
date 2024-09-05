using AutoMapper;
using HotelReservationSystem.DTO.Customer;
using HotelReservationSystem.Models;
using HotelReservationSystem.ViewModels.Customer;

namespace HotelReservationSystem.Profiles
{
    public class CustomerProfile:Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerViewModel,CustomerDTO>().ReverseMap();
            CreateMap<CustomerDTO, Customer>().ReverseMap();
        }
    }
}
