using HotelReservationSystem.Models;

namespace HotelReservationSystem.DTO.Room
{
    public class RoomResponseDTO
    {
        public int ID { get; set; }
        public RoomType roomType { get; set; }
        public LuxuryLevel luxuryLevel { get; set; }

        public double Price { get; set; }
        //public List<string> Pictures { get; set; }

        //public List<int> FacilitiesIDs { get; set; }
        //public bool IsAvailable { get; set; }
    }
}
