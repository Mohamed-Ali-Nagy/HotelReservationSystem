using HotelReservationSystem.DTO.Room;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.Services.RoomServices
{
    public interface IRoomService
    {
        public void Delete(int roomID);
        public void Update(RoomUpdateDTO roomUpdateDTO);
        public RoomResponseDTO Get(int  id);
        public int UpdateRoomPictures(RoomPicturesDTO roomPicturesDTO);
        public RoomResponseDTO Add(RoomCreateDTO roomCreateDTO);
        public IEnumerable<string> GetRoomPictures(int roomID);
    }
}
