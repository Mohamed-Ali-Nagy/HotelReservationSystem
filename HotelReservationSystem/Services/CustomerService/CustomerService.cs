using HotelReservationSystem.DTO.Customer;
using HotelReservationSystem.DTO.Reservation;
using HotelReservationSystem.DTO.Review;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Models;
using HotelReservationSystem.Repositories;

namespace HotelReservationSystem.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _repository;

        public CustomerService(IRepository<Customer> repository)
        {
            _repository = repository;
        }
        public CustomerDTO Add(CustomerDTO customerDTO)
        {
            Customer review = _repository.Add(customerDTO.MapOne<Customer>());
            _repository.SaveChanges();
            return review.MapOne<CustomerDTO>();
        }

        public void Delete(CustomerDTO customerDTO)
        {
            Customer customer = customerDTO.MapOne<Customer>();

            _repository.Delete(customer);
            _repository.SaveChanges();
        }

        public IEnumerable<CustomerDTO> GetAll()
        {
            var Reviews = _repository.GetAll();

            return Reviews.Map<CustomerDTO>();
        }

        public CustomerDTO GetByID(int id)
        {
            var Reviews = _repository.GetByID(id);

            return Reviews.MapOne<CustomerDTO>();
        }

        public CustomerDTO Update(int id,CustomerDTO customerDTO)
        {
            Customer customer = customerDTO.MapOne<Customer>();

            var cust=_repository.GetByID(id);
            customer.ID= cust.ID;
            Customer returnReview = _repository.Update(customer);
            _repository.SaveChanges();
            return returnReview.MapOne<CustomerDTO>();

        }
    }
}
