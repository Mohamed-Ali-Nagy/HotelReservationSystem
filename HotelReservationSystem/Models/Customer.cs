using System.ComponentModel.DataAnnotations;

namespace HotelReservationSystem.Models
{
    public class Customer : BaseModel
    {

        public string FullName { get; set; }
        public string Email { get; set; }

        public string? Braintree_ID { get; set; }
        public string Phone { get; set; }
        [Required]
        public int UserID { get; set; }
        public User User { get; set; }

        public List<Reservation>? Reservation { get; set; }

    }
}
