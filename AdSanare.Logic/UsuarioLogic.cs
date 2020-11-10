using AdSanare.Entities;
using AdSanare.Logic.Interfaces;
using AdSanare.UOW.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AdSanare.Logic
{
    public class UsuarioLogic : IUsuarioLogic
    {
        private readonly IUserUnitOfWork _unitOfWork;

        public UsuarioLogic(IUserUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Usuario nuevoUsuario)
        {
            _unitOfWork.Usuarios.Add(nuevoUsuario);
            _unitOfWork.Complete();
        }

        public IEnumerable<Usuario> Get()
        {
            return _unitOfWork.Usuarios.Get();
        }

        public Usuario Get(string Id)
        {
            return _unitOfWork.Usuarios.Get(Id);
        }

        public IEnumerable<Usuario> Get(List<Expression<Func<Usuario, bool>>> filtros = null, Func<IQueryable<Usuario>, IOrderedQueryable<Usuario>> ordenamiento = null, string incluir = "")
        {
            return _unitOfWork.Usuarios.Get(filtros, ordenamiento, incluir);
        }

        public Usuario GetByName(string nombreUsuario)
        {
            return _unitOfWork.Usuarios.GetByUserName(nombreUsuario);
        }

        public void Remove(int Id)
        {
            Usuario user = _unitOfWork.Usuarios.Get(Id);
            if (user != null)
            {
                _unitOfWork.Usuarios.Remove(user);
                _unitOfWork.Complete();
            }
        }

        public void Update(Usuario usuario)
        {
            _unitOfWork.Usuarios.Update(usuario);
            _unitOfWork.Complete();
        }
    }
}
