using HotelReservationSystem.DTO.Room;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Services.ReservationServices;
using HotelReservationSystem.Services.RoomServices;

namespace HotelReservationSystem.Mediators.RoomAvailability
{
    public class RoomAvailabilityMediator : IRoomAvailabilityMediator
    {
        IRoomService _roomService;
        IReservationService _reservationService;

        public RoomAvailabilityMediator(IRoomService roomService
            ,IReservationService reservationService)
        {
            _roomService = roomService;
            _reservationService = reservationService;
        }
        
        

        public IEnumerable<RoomResponseDTO> SearchRoomsAvailability(DateTime FilterDate)
        {
            var roomsReservedDTO =  _reservationService.GetAllRoomsReserved(FilterDate);

            var roomsAvailabilityDTO = _roomService.SearchRoomsAvailability(roomsReservedDTO);




            return roomsAvailabilityDTO;
        }

        
    }
}
