using HotelReservationSystem.Models;

namespace HotelReservationSystem.DTO.Room
{
    public class RoomCreateVM
    {
        public RoomType roomType { get; set; }
        public LuxuryLevel luxuryLevel { get; set; }

        public double Price { get; set; }
        public List<string> Pictures { get; set; }

    }
}
