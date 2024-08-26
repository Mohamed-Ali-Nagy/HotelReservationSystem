using HotelReservationSystem.DTO.Reservation;
using HotelReservationSystem.DTO.Room;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Mediators.Room;
using HotelReservationSystem.Mediators.RoomAvailability;
using HotelReservationSystem.Models;
using HotelReservationSystem.ViewModels;
using HotelReservationSystem.ViewModels.Reservation;
using HotelReservationSystem.ViewModels.Room;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HotelReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {

        private readonly IRoomMediator _roomMediator;
        private readonly IRoomAvailabilityMediator _roomAvailabilityMediator;

        public RoomController(IRoomMediator roomMediator 
            ,IRoomAvailabilityMediator roomAvailabilityMediator)
        {
            _roomMediator = roomMediator;
            _roomAvailabilityMediator = roomAvailabilityMediator;

        }
        
        [HttpGet("Get")]
        public IActionResult Get(int id)
        {
            var roomResponseDTO= _roomMediator.Get(id);
            return Ok(ResultViewModel<RoomResponseVM>.Success(roomResponseDTO.MapOne<RoomResponseVM>()));

        }

        [HttpPost("Add")]
        public IActionResult Add(RoomCreateVM roomCreateViewModel)
        {
            var roomResponseDTO = _roomMediator.Add(roomCreateViewModel.MapOne<RoomCreateDTO>());
            var roomResponseVM=roomResponseDTO.MapOne<RoomResponseVM>();
            return Ok(ResultViewModel<RoomResponseVM>.Success(roomResponseVM, "Room added successfully"));
        }

        [HttpPut("UpdateRoomPictures")]
        public IActionResult UpdateRoomPictures(RoomPicturesVM roomPicturesVM)
        {
            int roomID = _roomMediator.UpdateRoomPictures(roomPicturesVM.MapOne<RoomPicturesDTO>());
            return Ok(ResultViewModel<int>.Success(roomID));
        }

        [HttpGet("GetRoomPictures")]
        public IActionResult GetRoomPictures(int roomID)
        {
          var pictures=  _roomMediator.GetRoomPictures(roomID);
            return Ok(ResultViewModel<List<string>>.Success(pictures,""));
        }

        [HttpPut("Update")]
        public IActionResult Update(RoomUpdateVM roomUpdateVM)
        {
            var roomUpdateDTO=roomUpdateVM.MapOne<RoomUpdateDTO>();
            _roomMediator.Update(roomUpdateDTO);
            return Ok(ResultViewModel<int>.Success(roomUpdateDTO.ID));
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int roomID)
        {
            _roomMediator.Delete(roomID);
            return Ok(ResultViewModel<bool>.Success(true,""));
        }


        [HttpPost("SearchRoomsAvailability")]
        public IActionResult SearchRoomsAvailability(FilterRooms filterRooms)
        {

            var RoomsVM = _roomAvailabilityMediator.SearchRoomsAvailability(filterRooms.FilterDate)
                .Select(x => x.MapOne<RoomResponseDTO>());

            return Ok(ResultViewModel<RoomResponseDTO>.Success(RoomsVM));

        }

    }
}
