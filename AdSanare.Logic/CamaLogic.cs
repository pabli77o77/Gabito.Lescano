using AdSanare.Entities;
using AdSanare.Logic.Interfaces;
using AdSanare.UOW.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AdSanare.Logic
{
    public class CamaLogic : ICamaLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public CamaLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Cama entidad)
        {
            Servicio servicio = _unitOfWork.Servicios.Get(entidad.ServicioInternacion.Id);
            entidad.ServicioInternacion = servicio;
            _unitOfWork.Camas.Add(entidad);
            _unitOfWork.Complete();
        }

        public IEnumerable<Cama> Get()
        {
            return _unitOfWork.Camas.Get();
        }

        public Cama Get(int Id)
        {
            return _unitOfWork.Camas.Get(Id);
        }

        public IEnumerable<Cama> Get(List<Expression<Func<Cama, bool>>> where = null, Func<IQueryable<Cama>, IOrderedQueryable<Cama>> orden = null, string include = "")
        {
            return _unitOfWork.Camas.Get(where, orden, include);
        }

        public void Remove(int Id)
        {
            Cama cama = _unitOfWork.Camas.Get(Id);
            if (cama != null)
            {
                _unitOfWork.Camas.Remove(cama);
                _unitOfWork.Complete();
            }
        }

        public void Update(Cama entidad)
        {
            _unitOfWork.Camas.Update(entidad);
            _unitOfWork.Complete();
        }
    }
}
