using AdSanare.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AdSanare.Logic.Interfaces
{
    public interface ICamaLogic
    {
        void Add(Cama entidad);
        IEnumerable<Cama> Get();
        Cama Get(int Id);
        IEnumerable<Cama> Get(List<Expression<Func<Cama, bool>>> where = null, Func<IQueryable<Cama>, IOrderedQueryable<Cama>> orden = null, string include = "");
        void Remove(int Id);
        void Update(Cama entidad);
    }
}
