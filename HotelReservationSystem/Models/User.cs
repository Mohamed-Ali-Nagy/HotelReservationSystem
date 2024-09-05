namespace HotelReservationSystem.Models
{
    public class User:BaseModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }

    }
    public enum Role
    {
        Admin,
        Staff,
        Customre
    }
}
