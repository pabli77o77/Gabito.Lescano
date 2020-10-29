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

        public void Add(Usuario entidad)
        {
            _unitOfWork.Usuarios.Add(entidad);
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

        public IEnumerable<Usuario> Get(List<Expression<Func<Usuario, bool>>> where = null, Func<IQueryable<Usuario>, IOrderedQueryable<Usuario>> orden = null, string include = "")
        {
            return _unitOfWork.Usuarios.Get(where, orden, include);
        }

        public Usuario GetByName(string Name)
        {
            return _unitOfWork.Usuarios.GetByUserName(Name);
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

        public void Update(Usuario entidad)
        {
            _unitOfWork.Usuarios.Update(entidad);
            _unitOfWork.Complete();
        }
    }
}
