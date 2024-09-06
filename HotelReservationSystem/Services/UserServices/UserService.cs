using HotelReservationSystem.DTO.UserDTOs;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Models;
using HotelReservationSystem.Repositories;
using HotelReservationSystem.ViewModels.UserVMs;

namespace HotelReservationSystem.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;
        public UserService(IRepository<User> repository)
        {
            _repository = repository;
        }
        public bool Authenticated(UserLoginDTO userLoginDTO)
        {
            var user = _repository.GetAll().Where(u => u.UserName == userLoginDTO.UserName && u.Password == userLoginDTO.Password).FirstOrDefault();
            if (user == null)
            {
                return false;
            }
            return true;
        }

        public string GenerateToken(UserLoginDTO userLoginDTO)
        {
            var user = _repository.GetAll().Where(u => u.UserName == userLoginDTO.UserName && u.Password == userLoginDTO.Password).FirstOrDefault();

            string token = TokenHandler.GenerateToken(user.UserName, user.Role.ToString());
            return token;
        }

        public bool CheckUserName(string userName)
        {
         bool result=   _repository.GetAll().Any(u => u.UserName == userName);
            return result;
        }

        public void AddUser(UserRegisterDTO userRegisterDTO)
        {
            userRegisterDTO.Role = Role.Customre;
            _repository.Add(userRegisterDTO.MapOne<User>());
            _repository.SaveChanges();

        }
    }
}
