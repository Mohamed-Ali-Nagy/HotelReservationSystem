using HotelReservationSystem.DTO.UserDTOs;
using HotelReservationSystem.Exceptions;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Services.UserServices;
using HotelReservationSystem.ViewModels;
using HotelReservationSystem.ViewModels.UserVMs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Login")]
        public IActionResult Login(UserLoginVM userLoginVM)
        {
            var isAuthenticated = _userService.Authenticated(userLoginVM.MapOne<UserLoginDTO>());
            if (isAuthenticated)
            {
                var token = _userService.GenerateToken(userLoginVM.MapOne<UserLoginDTO>());
                return Ok(ResultViewModel<string>.Success(token, "login successfully"));
            }
            return Ok(ResultViewModel<bool>.Faliure("UnAuthorized", ErrorCode.UnAuthorized));
        }




    }
}
