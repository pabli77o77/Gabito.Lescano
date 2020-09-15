using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AdSanare.Repository.Interfaces
{
    public interface IGenericRepository<T> where T: class
    {
        IEnumerable<T> Get();
        T Get(int Id);
        IEnumerable<T> Get( List<Expression<Func<T,bool>>> where=null, Func<IQueryable<T>, IOrderedQueryable<T>> orden=null,string include="");
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
