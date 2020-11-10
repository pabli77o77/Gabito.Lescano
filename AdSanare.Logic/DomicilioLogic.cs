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
        public void Add(Domicilio domicilioNuevo)
        {
            _unitOfWork.Domicilios.Add(domicilioNuevo);
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

        public IEnumerable<Domicilio> Get(List<Expression<Func<Domicilio, bool>>> filtros = null, Func<IQueryable<Domicilio>, IOrderedQueryable<Domicilio>> ordenamiento = null, string incluir = "")
        {
            return _unitOfWork.Domicilios.Get(filtros, ordenamiento, incluir);
        }

        public void Remove(int Id)
        {
            Domicilio domicilio = _unitOfWork.Domicilios.Get(Id);
            if (domicilio != null)
            {
                domicilio.BajaLogica = true;
                domicilio.FechaBaja = DateTime.Now;
                _unitOfWork.Domicilios.Update(domicilio);
                _unitOfWork.Complete();
            }
        }

        public void Update(Domicilio domicilio)
        {
            _unitOfWork.Domicilios.Update(domicilio);
            _unitOfWork.Complete();
        }
    }
}
