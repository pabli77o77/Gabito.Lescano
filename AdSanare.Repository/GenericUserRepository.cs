using AdSanare.Context;
using AdSanare.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AdSanare.Repository
{
    public class GenericUserRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AdSanareUsuariosDbContext _context;
        public GenericUserRepository(AdSanareUsuariosDbContext context)
        {
            _context = context;
        }
        public virtual void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public virtual IEnumerable<T> Get()
        {
            return _context.Set<T>().ToList();
        }

        public virtual T Get(int Id)
        {
            return _context.Set<T>().Find(Id);
        }

        public virtual IEnumerable<T> Get(List<Expression<Func<T, bool>>> where = null, Func<IQueryable<T>, IOrderedQueryable<T>> orden = null, string include = "")
        {
            IQueryable<T> query = _context.Set<T>();
            if (where != null && where.Count() > 0)
            {
                foreach (Expression<Func<T, bool>> filtro in where)
                {
                    query = query.Where(filtro);
                }
            }
            foreach (var incluir in include.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(incluir);
            }
            if (orden != null)
            {
                return orden(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public virtual void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
