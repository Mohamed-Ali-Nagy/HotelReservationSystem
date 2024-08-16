namespace HotelReservationSystem.Models
{
    public class Offer:BaseModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Discount { get; set; }
        public List<RoomOffer> Rooms { get; set; }
    }
}
