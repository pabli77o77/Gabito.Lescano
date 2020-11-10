using AdSanare.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AdSanare.Logic.Interfaces
{
    public interface ICamaLogic
    {
        void Add(Cama cama);
        IEnumerable<Cama> Get();
        Cama Get(int Id);
        IEnumerable<Cama> Get(List<Expression<Func<Cama, bool>>> filtros = null, Func<IQueryable<Cama>, IOrderedQueryable<Cama>> ordenamiento = null, string incluir = "");
        void Remove(int Id);
        void Update(Cama cama);
    }
}
