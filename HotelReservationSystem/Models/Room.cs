using HotelReservationSystem.Models;

namespace HotelReservationSystem.Models
{
    public class Room:BaseModel
    {
        public RoomType Type { get; set; }
        public double Price { get; set; }
        public List<string> Pictures { get; set; }
        public Reservation Reservation { get; set; }
        public List<RoomFacilities> Facilities { get; set; }
        public bool IsAvailable { get; set; }
        public List<RoomOffer> Offers { get; set; }
    }
    public enum RoomType
    {
        None,
    }
}
