namespace HotelReservationSystem.ViewModels.Reservation
{
    public class ReservationViewModel
    {
        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public int RoomID { get; set; }

        public int CustomerID { get; set; }
    }
}
