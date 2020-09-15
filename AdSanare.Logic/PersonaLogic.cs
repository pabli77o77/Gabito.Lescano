using AdSanare.Entities;
using AdSanare.Logic.Interfaces;
using AdSanare.UOW.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AdSanare.Logic
{
    public class PersonaLogic : IPersonaLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        public PersonaLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(Persona entidad)
        {
            _unitOfWork.Personas.Add(entidad);
            _unitOfWork.Complete();
        }

        public IEnumerable<Persona> Get()
        {
            return _unitOfWork.Personas.Get();
        }

        public Persona Get(int Id)
        {
            return _unitOfWork.Personas.Get(Id);
        }

        public IEnumerable<Persona> Get(List<Expression<Func<Persona, bool>>> where = null, Func<IQueryable<Persona>, IOrderedQueryable<Persona>> orden = null, string include = "")
        {
            return _unitOfWork.Personas.Get(where, orden, include);            
        }

        public void Remove(int Id)
        {
            Persona persona= _unitOfWork.Personas.Get(Id);
            if (persona != null)
            {
                _unitOfWork.Personas.Remove(persona);
                _unitOfWork.Complete();
            }
        }

        public void Update(Persona entidad)
        {
            _unitOfWork.Personas.Update(entidad);
            _unitOfWork.Complete();
        }
    }
}
