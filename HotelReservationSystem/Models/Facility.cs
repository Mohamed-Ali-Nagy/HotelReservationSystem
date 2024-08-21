namespace HotelReservationSystem.Models
{
    public class Facility : BaseModel
    {
        public string Name { get; set; }
        public List<RoomFacilities> RoomsFacilites { get; set; }
    }
}
