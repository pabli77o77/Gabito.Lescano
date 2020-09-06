using System.Collections.Generic;

namespace AdSanare.Repository.Interfaces
{
    public interface IGenericRepository<T> where T: class
    {
        IEnumerable<T> GetAll();
        T GetById(int Id);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
