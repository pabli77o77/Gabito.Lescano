using AdSanare.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AdSanare.Logic.Interfaces
{
    public interface IServicioLogic
    {
        void Add(Servicio entidad);
        IEnumerable<Servicio> Get();
        Servicio Get(int Id);
        IEnumerable<Servicio> Get(List<Expression<Func<Servicio, bool>>> where = null, Func<IQueryable<Servicio>, IOrderedQueryable<Servicio>> orden = null, string include = "");
        void Remove(int Id);
        void Update(Servicio entidad);
    }
}
