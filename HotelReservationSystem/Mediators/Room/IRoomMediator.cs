using HotelReservationSystem.DTO.Room;

namespace HotelReservationSystem.Mediators.Room
{
    public interface IRoomMediator
    {
        public RoomResponseDTO Get(int id);
        public void Delete(int roomID);
        public void Update(RoomUpdateDTO roomUpdateDTO);
        public IEnumerable<string> GetRoomPictures(int roomID);
        RoomResponseDTO Add(RoomCreateDTO room);
        public int UpdateRoomPictures(RoomPicturesDTO roomPicturesDTO);


        //RoomResponseDTO Edit(int id, RoomEditViewModel room);
        //void Delete(int roomid);

        //List<RoomGetDTO> GetAll(int pageNumber, int pageSize);

    }
}
