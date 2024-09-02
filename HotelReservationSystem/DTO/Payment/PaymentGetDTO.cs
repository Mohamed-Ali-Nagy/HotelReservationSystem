using HotelReservationSystem.Models;

namespace HotelReservationSystem.DTO.Payment
{
    public class PaymentGetDTO
    {
        public decimal Amount { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime PaymentDate { get; set; }


        public List<int>? Reservation { get; set; }
        public int CustomerId { get; set; }

        //public Reservation Reservation { get; set; }

    }
}
