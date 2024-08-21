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
        
        public RoomResponseDTO Get(int id)
        {
           var roomResponseDTO= _roomService.Get(id);
            return roomResponseDTO;
        }
        public RoomResponseDTO Add(RoomCreateDTO roomCreateDTO)
        {
            var room = _roomService.Add(roomCreateDTO);
            return room;
        }
        public int UpdateRoomPictures(RoomPicturesDTO roomPicturesDTO)
        {
          int roomID=  _roomService.UpdateRoomPictures(roomPicturesDTO);
          return roomID;
        }
        public IEnumerable<string> GetRoomPictures(int roomID)
        {
           var roomPictures= _roomService.GetRoomPictures(roomID);
            return roomPictures;
        }

        public void Update(RoomUpdateDTO roomUpdateDTO)
        {
            _roomService.Update(roomUpdateDTO);
        }

        public void Delete(int roomID)
        {
            _roomService.Delete(roomID);
        }

        //public RoomEditDTO Edit(int id, RoomEditViewModel room)
        //{
        //    var roomViewModel = room.MapOne<RoomEditDTO>();

        //    _roomService.Edit(id, roomViewModel);
        //    return roomViewModel;
        //}
        //public List<RoomGetDTO> GetAll(int pageNumber, int pageSize)
        //{
        //    return _roomService.GetAll(pageNumber, pageSize);
        //}
    }
}
