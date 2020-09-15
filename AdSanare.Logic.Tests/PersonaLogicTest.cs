using AdSanare.Entities;
using AdSanare.Logic.Interfaces;
using AdSanare.Repository.Interfaces;
using AutoMoqCore;
using System;
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

            var mockPersonaRepository = _autoMoquer.GetMock<IPersonaRepository>();
            mockPersonaRepository.Setup(p => p.Get(personaId)).Returns(persona);

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

    }
}
