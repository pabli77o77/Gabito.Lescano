using AdSanare.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AdSanare.Logic.Interfaces
{
    public interface IIngresoLogic
    {
        void Add(Ingreso ingreso);
        IEnumerable<Ingreso> Get();
        Ingreso Get(int Id);
        IEnumerable<Ingreso> Get(List<Expression<Func<Ingreso, bool>>> filtros = null, Func<IQueryable<Ingreso>, IOrderedQueryable<Ingreso>> ordenamiento = null, string incluir = "");
        void Remove(int Id);
        void Update(Ingreso ingreso);

    }
}
