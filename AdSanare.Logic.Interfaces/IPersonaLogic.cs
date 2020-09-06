using AdSanare.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdSanare.Logic.Interfaces
{
    public interface IPersonaLogic
    {
        void Add(Persona entidad);
        IEnumerable<Persona> GetAll();
        Persona GetById(int Id);
        void Remove(Persona entidad);
        void Update(Persona entidad);
    }
}
