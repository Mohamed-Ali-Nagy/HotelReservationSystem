using System.Linq.Expressions;

namespace HotelReservationSystem.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        //IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        T GetByID(int id);
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
        //T First(Expression<Func<T, bool>> predicate);
        public IQueryable<T> GetAllPagination(int pageNumber, int pageSize);

        void SaveChanges();
    }
}
