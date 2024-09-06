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
        public IActionResult Login(UserRegistreVM userLoginVM)
        {
            var isAuthenticated = _userService.Authenticated(userLoginVM.MapOne<UserLoginDTO>());
            if (isAuthenticated)
            {
                var token = _userService.GenerateToken(userLoginVM.MapOne<UserLoginDTO>());
                return Ok(ResultViewModel<string>.Success(token, "login successfully"));
            }
            return Ok(ResultViewModel<bool>.Faliure("UnAuthorized", ErrorCode.UnAuthorized));
        }
        [HttpPost("Register")]
        public IActionResult Register(UserRegisterVM userRegisterVM)
        {
            var isExisted = _userService.CheckUserName(userRegisterVM.UserName);
            if (isExisted)
            {
                return Ok(ResultViewModel<bool>.Faliure("Invalid user name or password", ErrorCode.InvalidUserName));
            }
            _userService.AddUser(userRegisterVM.MapOne<UserRegisterDTO>());
            return Ok(ResultViewModel<bool>.Success(true,""));
        }



    }
}
