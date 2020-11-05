using AdSanare.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AdSanare.Logic.Interfaces
{
    public interface IObraSocialLogic
    {
        void Add(ObraSocial entidad);
        IEnumerable<ObraSocial> Get();
        ObraSocial Get(int Id);
        IEnumerable<ObraSocial> Get(List<Expression<Func<ObraSocial, bool>>> where = null, Func<IQueryable<ObraSocial>, IOrderedQueryable<ObraSocial>> orden = null, string include = "");
        void Remove(int Id);
        void Update(ObraSocial entidad);
    }
}
