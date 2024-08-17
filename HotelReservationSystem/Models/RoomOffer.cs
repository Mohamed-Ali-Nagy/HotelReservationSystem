using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationSystem.Models
{
    public class RoomOffer : BaseModel
    {
        [ForeignKey("Room")]
        public int RoomID { get; set; }
        public Room Room { get; set; }
        
        [ForeignKey("Offer")]
        public int OfferID { get; set; }
        public Offer Offer { get; set; }
    }
}
