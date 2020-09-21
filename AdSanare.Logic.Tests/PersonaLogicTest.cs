using AdSanare.Entities;
using AdSanare.Logic.Interfaces;
using AdSanare.Repository.Interfaces;
using AdSanare.UOW.Interfaces;
using AutoMoqCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AdSanare.Logic.Tests
{
    public class PersonaLogicTest
    {
        private readonly AutoMoqer _autoMoquer;
        private readonly IPersonaLogic _personaLogic;

        public PersonaLogicTest()
        {
            _autoMoquer = new AutoMoqer();
            _personaLogic = _autoMoquer.Resolve<PersonaLogic>();            
            _autoMoquer.GetMock<IUnitOfWork>().Setup(m => m.Personas).Returns(_autoMoquer.GetMock<IPersonaRepository>().Object);
        }

        [Fact]
        public void ObtienePersonaPorId()
        {
            int personaId = 3;
            
            Persona persona = new Persona
            {
                Id = personaId,
                Apellido = "Gomez",
                Nombre = "Jose",
                Documento = "46569878",
                ObraSocial = "OSDE",
                ObraSocialNumero = "6646464",
                Diagnostico = "Meningitis",
                FechaNacimiento = DateTime.Parse("1990-01-10")
            };

            Persona persona1 = (Persona)persona.Clone();

            _autoMoquer.GetMock<IPersonaRepository>().Setup(p => p.Get(personaId)).Returns(persona1);

            var result = _personaLogic.Get(personaId);

            Assert.Equal(persona.Id, result.Id);
            Assert.Equal(persona.Apellido, result.Apellido);
            Assert.Equal(persona.Nombre, result.Nombre);
            Assert.Equal(persona.Documento, result.Documento);
            Assert.Equal(persona.ObraSocial, result.ObraSocial);
            Assert.Equal(persona.ObraSocialNumero, result.ObraSocialNumero);
            Assert.Equal(persona.Diagnostico, result.Diagnostico);
            Assert.Equal(persona.FechaNacimiento, result.FechaNacimiento);
            
        }
        [Fact]
        public void ObtieneListaPersonas()
        {
            List<Persona> listado = new List<Persona>()
            {
                new Persona
                {
                    Id = 1,
                    Apellido = "Gomez",
                    Nombre = "Jose",
                    Documento = "46569878",
                    ObraSocial = "OSDE",
                    ObraSocialNumero = "6646464",
                    Diagnostico = "Meningitis",
                    FechaNacimiento = DateTime.Parse("1990-01-10")
                },
                new Persona
                {
                    Id = 2,
                    Apellido = "Perez",
                    Nombre = "Miguel",
                    Documento = "32132123",
                    ObraSocial = "OSDE",
                    ObraSocialNumero = "99977784",
                    Diagnostico = "Gripe",
                    FechaNacimiento = DateTime.Parse("1970-01-10")
                },
                new Persona
                {
                    Id = 3,
                    Apellido = "Lopez",
                    Nombre = "Raul",
                    Documento = "12345678",
                    ObraSocial = "Swiss Medical",
                    ObraSocialNumero = "232333",
                    Diagnostico = "Gastroenteritis",
                    FechaNacimiento = DateTime.Parse("1984-03-20")
                }

            };

            _autoMoquer.GetMock<IPersonaRepository>().Setup(p => p.Get()).Returns(listado);

            var result = _personaLogic.Get();

            Assert.True(result != null);
            Assert.Equal(listado.Count(), result.Count());
        }
    }
}
