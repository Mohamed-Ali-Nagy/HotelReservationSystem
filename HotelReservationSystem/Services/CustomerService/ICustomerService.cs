using HotelReservationSystem.DTO.Customer;
using HotelReservationSystem.DTO.Reservation;
using HotelReservationSystem.DTO.Review;

namespace HotelReservationSystem.Services.CustomerService
{
    public interface ICustomerService
    {
        IEnumerable<CustomerDTO> GetAll();

        CustomerDTO GetByID(int id);

        CustomerDTO Add(CustomerDTO reviewDTO);

        CustomerDTO Update(int id,CustomerDTO reviewDTO);

        void Delete(CustomerDTO reviewDTO);
    }
}
