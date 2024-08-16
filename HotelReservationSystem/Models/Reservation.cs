using HotelReservationSystem.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationSystem.Models
{
    public class Reservation:BaseModel
    {
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        [ForeignKey("Room")]
        public int RoomID { get; set; }
        public Room Room { get; set; }


    }
}
