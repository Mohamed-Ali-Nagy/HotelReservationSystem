using HotelReservationSystem.DTO.Room;

namespace HotelReservationSystem.Mediators.RoomAvailability
{
    public interface IRoomAvailabilityMediator
    {

        public IEnumerable<RoomResponseDTO> SearchRoomsAvailability(DateTime FilterDate);



    }
}
