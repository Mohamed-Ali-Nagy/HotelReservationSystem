using HotelReservationSystem.DTO.Room;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Services.RoomServices;

namespace HotelReservationSystem.Mediators.Room
{
    public class RoomMediator : IRoomMediator
    {
        IRoomService _roomService;

        public RoomMediator(IRoomService roomService)
        {
            _roomService = roomService;
        }
        public RoomCreateDTO Add(RoomCreateViewModel room)
        {
            var roomViewModel = room.MapOne<RoomCreateDTO>();

            //IEnumerable<Room> r = room.Map<Room>();
            _roomService.Create(roomViewModel);
            return roomViewModel;
        }

        public void Delete(int roomid)
        {
            _roomService.Delete(roomid);
        }

        public RoomEditDTO Edit(int id, RoomEditViewModel room)
        {
            var roomViewModel = room.MapOne<RoomEditDTO>();

            _roomService.Edit(id, roomViewModel);
            return roomViewModel;
        }
    }
}
