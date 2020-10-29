using AdSanare.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AdSanare.Logic.Interfaces
{
    public interface IUsuarioLogic
    {
        void Add(Usuario entidad);
        IEnumerable<Usuario> Get();
        Usuario Get(string Id);
        Usuario GetByName(string Name);
        IEnumerable<Usuario> Get(List<Expression<Func<Usuario, bool>>> where = null, Func<IQueryable<Usuario>, IOrderedQueryable<Usuario>> orden = null, string include = "");
        void Remove(int Id);
        void Update(Usuario entidad);
    }
}
