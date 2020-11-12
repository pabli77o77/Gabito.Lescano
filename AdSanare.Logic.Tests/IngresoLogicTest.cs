using AdSanare.Context;
using AdSanare.Entities;
using AdSanare.Logic.Interfaces;
using AdSanare.Repository.Interfaces;
using AdSanare.UOW.Interfaces;
using AutoMoqCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Xunit;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;

namespace AdSanare.Logic.Tests
{
    public class IngresoLogicTest
    {
        private readonly AutoMoqer _autoMoquer;
        private readonly IIngresoLogic _ingresoLogic;

        public IngresoLogicTest()
        {
            _autoMoquer = new AutoMoqer();
            _ingresoLogic = _autoMoquer.Resolve<IngresoLogic>();
            _autoMoquer.GetMock<IUnitOfWork>().Setup(i => i.Ingresos).Returns(_autoMoquer.GetMock<IIngresoRepository>().Object).Verifiable();
            _autoMoquer.GetMock<IUnitOfWork>().Setup(p => p.Pacientes).Returns(_autoMoquer.GetMock<IPacienteRepository>().Object).Verifiable();

        }

        [Fact]
        public void ObtieneIngresoPorId()
        {
            int idIngreso = 25;
            ObraSocial obSocial = new ObraSocial
            {
                Descripcion = "Swiss Medical",
                Id = 154
            };

            Paciente paciente = new Paciente
            {
                Apellido = "Gomez",
                Nombre = "Claudio",
                Documento = "12345678",
                Domicilio = new Domicilio { Calle = "Lafinur", Id = 1, Localidad = "Capital Federal", Provincia = "Bs. As." },
                EstadoCivil = "Casado",
                FechaNacimiento = Convert.ToDateTime("25/09/1980"),
                Id = 575,
                ObraSocial = obSocial,
                ObraSocialNumero = "54635-7389393",
                Sexo = "M",
                Telefono = "1156789944"
            };

            Ingreso ingreso = new Ingreso
            {
                Alergias = "Ninguna",
                AntecedentesMedicos = "Ninguno",
                AntecedentesQuirurgicos = "Ninguno",
                Defuncion = false,
                Diagnostico = "Gripe",
                FechaEgreso = null,
                FechaIngreso = DateTime.Now,
                Id = idIngreso,
                MedicacionHabitual = "Ninguna",
                Paciente = paciente,
                Peso = 80,
                Talla = 175
            };
            
            Ingreso ingreso1 = ingreso;

            _autoMoquer.GetMock<IIngresoRepository>().Setup(i => i.Get(idIngreso)).Returns(ingreso1);

            var result = _ingresoLogic.Get(idIngreso);

            Assert.Equal(ingreso.Id, result.Id);
            Assert.Equal(ingreso.FechaIngreso, result.FechaIngreso);
            Assert.Equal(ingreso.Peso, result.Peso);
            Assert.Equal(ingreso.Talla, result.Talla);
            Assert.Equal(ingreso.Diagnostico, result.Diagnostico);
            Assert.Equal(ingreso.FechaEgreso, result.FechaEgreso);
            Assert.Equal(ingreso.FechaIngreso, result.FechaIngreso);
            Assert.Equal(ingreso.MedicacionHabitual, result.MedicacionHabitual);
            Assert.Equal(ingreso.AntecedentesMedicos, result.AntecedentesMedicos);
            Assert.Equal(ingreso.AntecedentesQuirurgicos, result.AntecedentesQuirurgicos);
            Assert.Equal(ingreso.Defuncion, result.Defuncion);
            Assert.Equal(ingreso.Paciente, result.Paciente);
        }

        [Fact]
        public void ObtieneListaIngresos()
        {
            ObraSocial obSocial = new ObraSocial
            {
                Descripcion = "Swiss Medical",
                Id = 154
            };

            Paciente paciente = new Paciente
            {
                Apellido = "Gomez",
                Nombre = "Claudio",
                Documento = "12345678",
                Domicilio = new Domicilio { Calle = "Lafinur", Id = 1, Localidad = "Capital Federal", Provincia = "Bs. As." },
                EstadoCivil = "Casado",
                FechaNacimiento = Convert.ToDateTime("25/09/1980"),
                Id = 575,
                ObraSocial = obSocial,
                ObraSocialNumero = "54635-7389393",
                Sexo = "M",
                Telefono = "1156789944"
            };

            List<Ingreso> listaIngresos = new List<Ingreso>()
            {

                new Ingreso
                {
                    Alergias = "Ninguna",
                    AntecedentesMedicos = "Ninguno",
                    AntecedentesQuirurgicos = "Ninguno",
                    Defuncion = false,
                    Diagnostico = "Gripe",
                    FechaEgreso = null,
                    FechaIngreso = DateTime.Now,
                    Id = 25,
                    MedicacionHabitual = "Ninguna",
                    Paciente = paciente,
                    Peso = 80,
                    Talla = 175
                },

                new Ingreso
                {
                    Alergias = "Si",
                    AntecedentesMedicos = "Ya tiene un ingreso",
                    AntecedentesQuirurgicos = "No",
                    Defuncion = false,
                    Diagnostico = "Fractura",
                    FechaEgreso = null,
                    FechaIngreso = DateTime.Now,
                    Id = 46,
                    MedicacionHabitual = "Ninguna",
                    Paciente = paciente,
                    Peso = 80,
                    Talla = 175
                },

                new Ingreso
                {
                    Alergias = "Penicilina",
                    AntecedentesMedicos = "Intervención",
                    AntecedentesQuirurgicos = "Apéndice",
                    Defuncion = false,
                    Diagnostico = "Diagnóstico",
                    FechaEgreso = null,
                    FechaIngreso = DateTime.Now,
                    Id = 77,
                    MedicacionHabitual = "Ninguna",
                    Paciente = paciente,
                    Peso = 80,
                    Talla = 175
                },
            };

            _autoMoquer.GetMock<IIngresoRepository>().Setup(i => i.Get()).Returns(listaIngresos);
            var result = _ingresoLogic.Get();
            
            Assert.True(result != null);
            Assert.Equal(listaIngresos.Count, result.Count());
        }
    }
}
