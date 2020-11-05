using AdSanare.Entities;
using AdSanare.Logic.Interfaces;
using AdSanare.UOW.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AdSanare.Logic
{
    public class DomicilioLogic : IDomicilioLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public DomicilioLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(Domicilio entidad)
        {
            _unitOfWork.Domicilios.Add(entidad);
            _unitOfWork.Complete();
        }

        public IEnumerable<Domicilio> Get()
        {
            return _unitOfWork.Domicilios.Get();
        }

        public Domicilio Get(int Id)
        {
            return _unitOfWork.Domicilios.Get(Id);
        }

        public IEnumerable<Domicilio> Get(List<Expression<Func<Domicilio, bool>>> where = null, Func<IQueryable<Domicilio>, IOrderedQueryable<Domicilio>> orden = null, string include = "")
        {
            return _unitOfWork.Domicilios.Get(where, orden, include);
        }

        public void Remove(int Id)
        {
            Domicilio domicilio = _unitOfWork.Domicilios.Get(Id);
            if (domicilio != null)
            {
                _unitOfWork.Domicilios.Remove(domicilio);
                _unitOfWork.Complete();
            }
        }

        public void Update(Domicilio entidad)
        {
            _unitOfWork.Domicilios.Update(entidad);
            _unitOfWork.Complete();
        }
    }
}
