using HotelReservationSystem.DTO.Customer;
using HotelReservationSystem.DTO.FacilityDTOs;
using HotelReservationSystem.DTO.Review;

namespace HotelReservationSystem.Mediators.CustomerMediators
{
    public interface ICustomerMeditator
    {
        public CustomerDTO Add(CustomerDTO reviewDTO);
        public void Update(CustomerDTO reviewDTO);
        public void Delete(int id);
        public CustomerDTO Get(int id);
        //public IEnumerable<ReviewDTO> GetAll();
    }
}
