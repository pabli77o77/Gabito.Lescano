using AdSanare.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AdSanare.Logic.Interfaces
{
    public interface IIngresoLogic
    {
        void Add(Ingreso entidad);
        IEnumerable<Ingreso> Get();
        Ingreso Get(int Id);
        IEnumerable<Ingreso> Get(List<Expression<Func<Ingreso, bool>>> where = null, Func<IQueryable<Ingreso>, IOrderedQueryable<Ingreso>> orden = null, string include = "");
        void Remove(int Id);
        void Update(Ingreso entidad);

    }
}
