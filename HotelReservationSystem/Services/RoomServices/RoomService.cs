using HotelReservationSystem.DTO.Room;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Models;
using HotelReservationSystem.Repositories;

namespace HotelReservationSystem.Services.RoomServices
{
    public class RoomService : IRoomService
    {
        private readonly IRepository<Room> _roomRepository;

        public RoomService(IRepository<Room> roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public Room Create(RoomCreateDTO room)
        {
            var roomDTO = room.MapOne<Room>();
            roomDTO.IsAvailable = true;
            var newRoom = _roomRepository.Add(roomDTO);
            _roomRepository.SaveChanges();
            return newRoom;
        }

        public Room Edit(int id, RoomEditDTO room)
        {
            var roomDTO = room.MapOne<Room>();
            roomDTO.ID = id;
            _roomRepository.Update(roomDTO);
            _roomRepository.SaveChanges();
            return roomDTO;
        }

        public void Delete(int id)
        {
            _roomRepository.Delete(id);
            _roomRepository.SaveChanges();
        }
    }

}
