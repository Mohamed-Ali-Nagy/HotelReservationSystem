using HotelReservationSystem.Models;

namespace HotelReservationSystem.DTO.Payment
{
    public class PaymentCreateDTO
    {
        public decimal Amount { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethodNonce { get; set; }


        public int ReservationId { get; set; }
        public int CustomerId { get; set; }

        //public Reservation Reservation { get; set; }
    }
}
