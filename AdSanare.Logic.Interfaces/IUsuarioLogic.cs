using AdSanare.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AdSanare.Logic.Interfaces
{
    public interface IUsuarioLogic
    {
        void Add(Usuario usuario);
        IEnumerable<Usuario> Get();
        Usuario Get(string Id);
        Usuario GetByName(string NombreUsuario);
        IEnumerable<Usuario> Get(List<Expression<Func<Usuario, bool>>> filtros = null, Func<IQueryable<Usuario>, IOrderedQueryable<Usuario>> ordenamiento = null, string incluir = "");
        void Remove(int Id);
        void Update(Usuario usuario);
    }
}
