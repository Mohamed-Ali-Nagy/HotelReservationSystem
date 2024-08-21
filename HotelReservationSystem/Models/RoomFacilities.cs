using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationSystem.Models
{
    public class RoomFacilities : BaseModel
    {
        [ForeignKey("Room")]
        public int RoomID { get; set; }
        public Room Room { get; set; }
        [ForeignKey("Facility")]
        public int FacilityID { get; set; }
        public Facility Facility { get; set; }
    }
}
