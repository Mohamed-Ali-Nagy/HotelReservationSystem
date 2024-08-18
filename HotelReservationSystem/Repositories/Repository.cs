using HotelReservationSystem.Data;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseModel, new()
    {
        protected Context _context;

        public Repository(Context context)
        {
            _context = context;
        }

        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            entity.IsDeleted = true;
            Update(entity);
        }



        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().Where(a => a.IsDeleted != true);
        }

        public T GetByID(int id)
        {
            return _context.Set<T>().FirstOrDefault(a => a.IsDeleted != true && a.ID == id);
        }

        public void Delete(int id)
        {
            T entity = _context.Find<T>(id);
            Delete(entity);
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public T Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return entity;
        }


    }
}
