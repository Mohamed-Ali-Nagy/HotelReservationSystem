using HotelReservationSystem.DTO.Room;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.Services.RoomServices
{
    public interface IRoomService
    {
        Room Create(RoomCreateDTO room);
        Room Edit(int id, RoomEditDTO room);
        void Delete(int id);
    }
}
