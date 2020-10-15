using AdSanare.Entities;
using AdSanare.Logic.Interfaces;
using AdSanare.UOW.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AdSanare.Logic
{
    public class ServicioLogic : IServicioLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServicioLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(Servicio entidad)
        {
            _unitOfWork.Servicios.Add(entidad);
            _unitOfWork.Complete();
        }

        public IEnumerable<Servicio> Get()
        {
            return _unitOfWork.Servicios.Get();
        }

        public Servicio Get(int Id)
        {
            return _unitOfWork.Servicios.Get(Id);
        }

        public IEnumerable<Servicio> Get(List<Expression<Func<Servicio, bool>>> where = null, Func<IQueryable<Servicio>, IOrderedQueryable<Servicio>> orden = null, string include = "")
        {
            return _unitOfWork.Servicios.Get(where, orden, include);
        }

        public void Remove(int Id)
        {
            Servicio servicio = _unitOfWork.Servicios.Get(Id);
            if (servicio != null)
            {
                _unitOfWork.Servicios.Remove(servicio);
                _unitOfWork.Complete();
            }
        }

        public void Update(Servicio entidad)
        {
            _unitOfWork.Servicios.Update(entidad);
            _unitOfWork.Complete();
        }
    }
}
