using HotelReservationSystem.Models;

namespace HotelReservationSystem.ViewModels.Room
{
    public class RoomResponseVM
    {
        public int ID { get; set; }
        public RoomType roomType { get; set; }
        public LuxuryLevel luxuryLevel { get; set; }
        public double Price { get; set; }
    }
}
