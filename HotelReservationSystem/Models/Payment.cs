using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationSystem.Models
{
    public class Payment:BaseModel
    {
        
            public decimal Amount { get; set; }
            public string PaymentStatus { get; set; }
            public DateTime PaymentDate { get; set; }
        public string PaymentMethodNonce { get; set; }


       
        public List<Reservation>? Reservation { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
