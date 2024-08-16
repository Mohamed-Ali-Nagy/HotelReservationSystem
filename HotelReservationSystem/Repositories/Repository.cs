using HotelReservationSystem.Models;

namespace HotelReservationSystem.Repositories
{
    public class Repository<T>:IRepository<T> where T : BaseModel
    {
    }
}
