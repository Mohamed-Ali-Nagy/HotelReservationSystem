using HotelReservationSystem.Models;
using System.Linq.Expressions;


namespace HotelReservationSystem.Repositories
{
    public interface IRepository<T> where T : BaseModel, new()
    {
       
        IQueryable<T> GetAll();
        T GetByID(int id);
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
        void Delete(int id);
        //T First(Expression<Func<T, bool>> predicate);
        public IQueryable<T> GetAllPagination(int pageNumber, int pageSize);

        void SaveChanges();
    }
}
