using HotelReservationSystem.DTO.Reservation;
using HotelReservationSystem.DTO.Room;
using HotelReservationSystem.Exceptions;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Models;
using HotelReservationSystem.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystem.Services.RoomServices
{
    public class RoomService : IRoomService
    {
        private readonly IRepository<Room> _roomRepository;

        public RoomService(IRepository<Room> roomRepository)
        {
            _roomRepository = roomRepository;
        }
        private Room GetByID(int id)
        {
            var room = _roomRepository.GetByID(id);
            if (room == null)
            {
                throw new BusinessException(ErrorCode.InvalidRoomID, "Room ID not found");
            }
            return room;
        }
        public RoomResponseDTO Get(int id)
        {
            var roomResponseDTO = GetByID(id).MapOne<RoomResponseDTO>();
            return roomResponseDTO;
        }
        public RoomResponseDTO Add(RoomCreateDTO roomCreateDTO)
        {
            var room = roomCreateDTO.MapOne<Room>();
            _roomRepository.Add(room);
            _roomRepository.SaveChanges();
            return room.MapOne<RoomResponseDTO>();
        }
        public int UpdateRoomPictures(RoomPicturesDTO roomPicturesDTO)
        {
            Room room = GetByID(roomPicturesDTO.RoomID);

            room.Pictures = roomPicturesDTO.Pictures;
            _roomRepository.Update(room);
            _roomRepository.SaveChanges();
            return room.ID;
        }

        public IEnumerable<string> GetRoomPictures(int roomID)
        {
            var room = GetByID(roomID);
            return room.Pictures;
        }

        public void Update(RoomUpdateDTO roomUpdateDTO)
        {
            var oldRoom = GetByID(roomUpdateDTO.ID);
            var newRoom = roomUpdateDTO.MapOne<Room>();
            newRoom.Pictures =oldRoom.Pictures;
            _roomRepository.Update(newRoom);
            _roomRepository.SaveChanges();

        }

        public void Delete(int roomID)
        {
           var room= GetByID(roomID);
            _roomRepository.Delete(room);
            _roomRepository.SaveChanges();
        }

        public IEnumerable<RoomResponseDTO> SearchRoomsAvailability(IEnumerable<RoomsReservedDTO> roomsReservedDTO)
        {

            var rooms = _roomRepository.GetAll()
                    .Where(room => roomsReservedDTO
                        .All(roomReserved => roomReserved.RoomID != room.ID)
                        );


            var roomsDTO = rooms.Map<RoomResponseDTO>();

            return roomsDTO;
        }


        //public Room Edit(int id, RoomEditDTO room)
        //{
        //    var roomDTO = room.MapOne<Room>();
        //    roomDTO.ID = id;
        //    _roomRepository.Update(roomDTO);
        //    _roomRepository.SaveChanges();
        //    return roomDTO;
        //}

        //public void Delete(int id)
        //{
        //    _roomRepository.Delete(id);
        //    _roomRepository.SaveChanges();
        //}



        //public List<RoomGetDTO> GetAll(int pageNumber, int pageSize)
        //{
        //    List<Room> rooms = _roomRepository.GetAllPagination(pageNumber, pageSize)
        //        .Where(a=>a.IsAvailable==true)
        //        .Include(a=>a.Facilities)
        //        .ToList();
        //    List<RoomGetDTO> roomsDTO = new List<RoomGetDTO>();
        //    foreach (var room in rooms)
        //    {
        //        roomsDTO.Add(room.MapOne<RoomGetDTO>());
        //    }
        //    return roomsDTO;
        //}

    }

}
