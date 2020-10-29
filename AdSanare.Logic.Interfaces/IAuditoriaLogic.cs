using AdSanare.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AdSanare.Logic.Interfaces
{
    public interface IAuditoriaLogic
    {
        void Add(Auditoria entidad);
        IEnumerable<Auditoria> Get();
        Auditoria Get(int Id);
        IEnumerable<Auditoria> Get(List<Expression<Func<Auditoria, bool>>> where = null, Func<IQueryable<Auditoria>, IOrderedQueryable<Auditoria>> orden = null, string include = "");
    }
}
