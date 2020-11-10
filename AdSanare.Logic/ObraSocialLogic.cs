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
        public void Add(ObraSocial nuevaObraSocial)
        {
            _unitOfWork.ObrasSociales.Add(nuevaObraSocial);
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

        public IEnumerable<ObraSocial> Get(List<Expression<Func<ObraSocial, bool>>> filtros = null, Func<IQueryable<ObraSocial>, IOrderedQueryable<ObraSocial>> ordenamiento = null, string incluir = "")
        {
            return _unitOfWork.ObrasSociales.Get(filtros, ordenamiento, incluir);
        }

        public void Remove(int Id)
        {
            ObraSocial obraSocial = _unitOfWork.ObrasSociales.Get(Id);
            if (obraSocial != null)
            {
                obraSocial.BajaLogica = true;
                obraSocial.FechaBaja = DateTime.Now;
                _unitOfWork.ObrasSociales.Update(obraSocial);
                _unitOfWork.Complete();
            }
        }

        public void Update(ObraSocial obraSocial)
        {
            _unitOfWork.ObrasSociales.Update(obraSocial);
            _unitOfWork.Complete();
        }
    }
}
