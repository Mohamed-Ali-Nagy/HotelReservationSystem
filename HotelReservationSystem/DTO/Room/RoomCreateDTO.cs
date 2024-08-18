using HotelReservationSystem.Models;

namespace HotelReservationSystem.DTO.Room
{
    public class RoomCreateDTO
    {
        public RoomType roomType { get; set; }
        public LuxuryLevel luxuryLevel { get; set; }

        public double Price { get; set; }
        public List<string> Pictures { get; set; }
        //public Reservation Reservation { get; set; }
        //public bool IsDeleted { get; set; } = false;

        public Facility Facilities { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}
