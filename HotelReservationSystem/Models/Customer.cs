namespace HotelReservationSystem.Models
{
    public class Customer : BaseModel
    {

        public string FullName { get; set; }


        public List<Reservation> Reservation { get; set; }

    }
}
