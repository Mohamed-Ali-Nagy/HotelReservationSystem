using Braintree;
using HotelReservationSystem.DTO.Payment;
using HotelReservationSystem.DTO.Room;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.Mediators.Payment
{
    public interface IPaymentMediator
    {
        PaymentCreateDTO Add(PaymentCreateDTO room);
        void AssignReservation(int id, List<int> ReservationIds);
        void Cancel(int roomid);
         List<PaymentGetDTO> GetAll(int pageNumber, int pageSize);



       // void CreateCustomer(Braintree.CustomerRequest request);
       // string GenerateClientToken(string customerId);

        void CreatePurchase(TransactionRequest request);

       // List<Braintree.Customer> GetAllCustomers();



    }
}
