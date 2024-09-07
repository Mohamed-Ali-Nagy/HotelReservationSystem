namespace HotelReservationSystem.ViewModels.Customer
{
    public class CustomerViewModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string? Braintree_ID { get; set; }
        public int UserID { get; set; }


        // public List<int>? Reservation { get; set; }
    }
}
