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
        public void Add(Servicio nuevoServicio)
        {
            _unitOfWork.Servicios.Add(nuevoServicio);
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

        public IEnumerable<Servicio> Get(List<Expression<Func<Servicio, bool>>> filtros = null, Func<IQueryable<Servicio>, IOrderedQueryable<Servicio>> ordenamiento = null, string incluir = "")
        {
            return _unitOfWork.Servicios.Get(filtros, ordenamiento, incluir);
        }

        public void Remove(int Id)
        {
            Servicio servicio = _unitOfWork.Servicios.Get(Id);
            if (servicio != null)
            {
                servicio.BajaLogica = true;
                servicio.FechaBaja = DateTime.Now;
                List<Expression<Func<Cama, bool>>> filtrosCama = new List<Expression<Func<Cama, bool>>>();
                filtrosCama.Add(x => x.ServicioInternacion.Id == Id);
                var camasServicio = _unitOfWork.Camas.Get(filtrosCama);
                foreach (Cama c in camasServicio)
                {
                    c.BajaLogica = true;
                    c.FechaBaja = DateTime.Now;
                    _unitOfWork.Camas.Update(c);
                }
                _unitOfWork.Servicios.Update(servicio);
                _unitOfWork.Complete();
            }
        }

        public void Update(Servicio servicio)
        {
            _unitOfWork.Servicios.Update(servicio);
            _unitOfWork.Complete();
        }
    }
}
