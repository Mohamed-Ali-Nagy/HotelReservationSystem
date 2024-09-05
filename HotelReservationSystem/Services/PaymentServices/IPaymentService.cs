using HotelReservationSystem.DTO.Payment;
using HotelReservationSystem.DTO.Room;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.Services.PaymentServices
{
    public interface IPaymentService
    {
        PaymentCreateDTO Add(PaymentCreateDTO room);
        void Update(int id, PaymentEditDTO room);
        PaymentGetDTO Get( int id);
        bool AssignReservation(int id, List<int> ReservationIds);

        void Cancel(int id);
        List<PaymentGetDTO> GetAll(int pageNumber, int pageSize);
    }
}
