

namespace HotelReservationSystem.DTO.Reservation
{
    public class ReservationDTO
    {

        public int ID { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public int RoomID { get; set; }

        public int CustomerID { get; set; }

    }
}
