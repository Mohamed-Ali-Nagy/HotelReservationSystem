using System.ComponentModel.DataAnnotations;

namespace HotelReservationSystem.Models
{
    public class BaseModel
    {
        [Key]
        public int ID { get; set; }

        public bool IsDeleted { get; set; }
    }
}
