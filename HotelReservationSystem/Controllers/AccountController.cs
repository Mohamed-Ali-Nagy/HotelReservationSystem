using HotelReservationSystem.DTO.Room;
using HotelReservationSystem.Models;
using HotelReservationSystem.Services.UserServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("adddddd")]
        public IActionResult addddddd(RoomCreateVM room)
        {
            return Ok();
        }
    }
}
