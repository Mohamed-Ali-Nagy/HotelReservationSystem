namespace HotelReservationSystem.Models
{
    public class Customer : BaseModel
    {


        public List<Reservation> Reservation { get; set; }

    }
}
