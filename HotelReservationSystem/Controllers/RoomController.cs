//using MediatR;
using Microsoft.AspNetCore.Mvc;
using HotelReservationSystem.Models;
//using HotelReservationSystem.Mediator;
using HotelReservationSystem.Mediators.Room;
using HotelReservationSystem.DTO.Room;

namespace HotelReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomMediator _room_mediator;

        public RoomController(IRoomMediator room_mediator)
        {
            _room_mediator = room_mediator;
        }

        [HttpPost("create")]
        public IActionResult CreateRoom([FromBody] RoomCreateViewModel room)
        {
            var createdRoom = _room_mediator.Add(room);
            return Ok(createdRoom);
        }

        [HttpPut("edit")]
        public IActionResult EditRoom(int id, [FromBody] RoomEditViewModel room)
        {
            var updatedRoom = _room_mediator.Edit(id, room);

            return Ok(updatedRoom);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteRoom(int id)
        {
            _room_mediator.Delete(id);
            return Ok();
        }


        [HttpGet("get")]
        public IActionResult GetAvailableRoom(int pageNumber, int pageSize)
        {
            var updatedRoom = _room_mediator.GetAll(pageNumber, pageSize);

            return Ok(updatedRoom);
        }

    }
}
