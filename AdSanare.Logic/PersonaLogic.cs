using AdSanare.Entities;
using AdSanare.Logic.Interfaces;
using AdSanare.UOW.Interfaces;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<Persona> GetAll()
        {
            return _unitOfWork.Personas.GetAll();
        }

        public Persona GetById(int Id)
        {
            return _unitOfWork.Personas.GetById(Id);
        }

        public void Remove(Persona entidad)
        {
            _unitOfWork.Personas.Remove(entidad);
            _unitOfWork.Complete();
        }

        public void Update(Persona entidad)
        {
            _unitOfWork.Personas.Update(entidad);
            _unitOfWork.Complete();
        }
    }
}
