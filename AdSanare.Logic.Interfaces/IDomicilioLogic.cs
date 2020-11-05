using AdSanare.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AdSanare.Logic.Interfaces
{
    public interface IDomicilioLogic
    {
        void Add(Domicilio entidad);
        IEnumerable<Domicilio> Get();
        Domicilio Get(int Id);
        IEnumerable<Domicilio> Get(List<Expression<Func<Domicilio, bool>>> where = null, Func<IQueryable<Domicilio>, IOrderedQueryable<Domicilio>> orden = null, string include = "");
        void Remove(int Id);
        void Update(Domicilio entidad);
    }
}
