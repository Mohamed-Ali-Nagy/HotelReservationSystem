using HotelReservationSystem.DTO.Room;

namespace HotelReservationSystem.Mediators.Room
{
    public interface IRoomMediator
    {
        RoomCreateDTO Add(RoomCreateViewModel room);
        RoomEditDTO Edit(int id, RoomEditViewModel room);
        void Delete(int roomid);

        List<RoomGetDTO> GetAll(int pageNumber, int pageSize);

    }
}
