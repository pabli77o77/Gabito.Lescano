using AdSanare.Core.Helper;
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
    public class PacienteLogicTest
    {
        private readonly AutoMoqer _autoMoquer;
        private readonly IPacienteLogic _pacienteLogic;

        public PacienteLogicTest()
        {
            _autoMoquer = new AutoMoqer();
            _pacienteLogic = _autoMoquer.Resolve<PacienteLogic>();            
            _autoMoquer.GetMock<IUnitOfWork>().Setup(m => m.Pacientes).Returns(_autoMoquer.GetMock<IPacienteRepository>().Object);
        }

        [Fact]
        public void ObtienePacientePorId()
        {
            int pacienteId = 3;
            
            Paciente paciente = new Paciente
            {
                Id = pacienteId,
                Apellido = "Gomez",
                Nombre = "Jose",
                Documento = "46569878",
                Sexo = "Masculino",
                EstadoCivil = "Soltero",
                ObraSocialNumero = "6646464",
                Telefono = "45551234",
                FechaNacimiento = DateTime.Parse("1990-01-10")
            };

            Paciente pacienteClonado = CloningService.Clone(paciente);

            _autoMoquer.GetMock<IPacienteRepository>().Setup(p => p.Get(pacienteId)).Returns(pacienteClonado);

            var result = _pacienteLogic.Get(pacienteId);

            Assert.Equal(paciente.Id, result.Id);
            Assert.Equal(paciente.Apellido, result.Apellido);
            Assert.Equal(paciente.Nombre, result.Nombre);
            Assert.Equal(paciente.Documento, result.Documento);
            Assert.Equal(paciente.ObraSocial, result.ObraSocial);
            Assert.Equal(paciente.ObraSocialNumero, result.ObraSocialNumero);
            Assert.Equal(paciente.Sexo, result.Sexo);
            Assert.Equal(paciente.EstadoCivil, result.EstadoCivil);
            Assert.Equal(paciente.Telefono, result.Telefono);
            Assert.Equal(paciente.FechaNacimiento, result.FechaNacimiento);
            
        }
        [Fact]
        public void ObtieneListaPacientes()
        {
            List<Paciente> listado = new List<Paciente>()
            {
                new Paciente
                {
                    Id = 1,
                    Apellido = "Gomez",
                    Nombre = "Jose",
                    Documento = "46569878",
                    Sexo = "Masculino",
                    EstadoCivil = "Soltero",
                    Telefono = "12345648",
                    ObraSocialNumero = "6646464",
                    FechaNacimiento = DateTime.Parse("1990-01-10")
                },
                new Paciente
                {
                    Id = 2,
                    Apellido = "Perez",
                    Nombre = "Miguel",
                    Documento = "32132123",
                    Sexo = "Masculino",
                    EstadoCivil = "Soltero",
                    Telefono = "12345648",
                    ObraSocialNumero = "99977784",
                    FechaNacimiento = DateTime.Parse("1970-01-10")
                },
                new Paciente
                {
                    Id = 3,
                    Apellido = "Lopez",
                    Nombre = "Raul",
                    Documento = "12345678",
                    Sexo = "Masculino",
                    EstadoCivil = "Soltero",
                    Telefono = "12345648",
                    ObraSocialNumero = "232333",
                    FechaNacimiento = DateTime.Parse("1984-03-20")
                }

            };
            List<Paciente> listadoPacientesClonado = new List<Paciente>();
            foreach(Paciente p in listado)
            {
                listadoPacientesClonado.Add(CloningService.Clone(p));
            }
            _autoMoquer.GetMock<IPacienteRepository>().Setup(p => p.Get()).Returns(listadoPacientesClonado);

            var result = _pacienteLogic.Get();

            Assert.True(result != null);
            Assert.Equal(listado.Count(), result.Count());
        }
    }
}
