using AdSanare.Entities;
using AdSanare.Logic.Interfaces;
using AdSanare.UOW.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AdSanare.Logic
{
    public class ObraSocialLogic : IObraSocialLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public ObraSocialLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(ObraSocial entidad)
        {
            _unitOfWork.ObrasSociales.Add(entidad);
            _unitOfWork.Complete();
        }

        public IEnumerable<ObraSocial> Get()
        {
            return _unitOfWork.ObrasSociales.Get();
        }

        public ObraSocial Get(int Id)
        {
            return _unitOfWork.ObrasSociales.Get(Id);
        }

        public IEnumerable<ObraSocial> Get(List<Expression<Func<ObraSocial, bool>>> where = null, Func<IQueryable<ObraSocial>, IOrderedQueryable<ObraSocial>> orden = null, string include = "")
        {
            return _unitOfWork.ObrasSociales.Get(where, orden, include);
        }

        public void Remove(int Id)
        {
            ObraSocial obra = _unitOfWork.ObrasSociales.Get(Id);
            if (obra != null)
            {
                _unitOfWork.ObrasSociales.Remove(obra);
                _unitOfWork.Complete();
            }
        }

        public void Update(ObraSocial entidad)
        {
            _unitOfWork.ObrasSociales.Update(entidad);
            _unitOfWork.Complete();
        }
    }
}
