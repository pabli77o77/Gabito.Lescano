using AdSanare.Core.Helper;
using AdSanare.Entities;
using AdSanare.Logic.Interfaces;
using AdSanare.Repository.Interfaces;
using AdSanare.UOW.Interfaces;
using AutoMoqCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace AdSanare.Logic.Tests
{
    public class ExamenComplementarioLogicTest
    {
        private readonly AutoMoqer _autoMoquer;
        private readonly IExamenComplementarioLogic _examenComplementarioLogic;

        public ExamenComplementarioLogicTest()
        {
            _autoMoquer = new AutoMoqer();
            _examenComplementarioLogic = _autoMoquer.Resolve<ExamenComplementarioLogic>();
            _autoMoquer.GetMock<IUnitOfWork>().Setup(e => e.ExamenesComplementarios).Returns(_autoMoquer.GetMock<IExamenComplementarioRepository>().Object);
        }

        [Fact]
        public void ObtenerExamenComplementarioPorId()
        {
            int idExamen = 32;
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

            ExamenComplementario examen = new ExamenComplementario
            {
                Detalle = "Examen_1",
                FechaExamen = DateTime.Now,
                Id = idExamen,
                Paciente = paciente,
                TipoExamen = "Complementario"
            };

            ExamenComplementario examenClonado = CloningService.Clone(examen);

            _autoMoquer.GetMock<IExamenComplementarioRepository>().Setup(e => e.Get(idExamen)).Returns(examenClonado);

            var result = _examenComplementarioLogic.Get(idExamen);
            Assert.Equal(examen.Id, result.Id);
            Assert.Equal(examen.Paciente.Id, result.Paciente.Id);
            Assert.Equal(examen.Detalle, result.Detalle);
            Assert.Equal(examen.FechaExamen, result.FechaExamen);
            Assert.Equal(examen.TipoExamen, result.TipoExamen);
        }

        [Fact]
        public void ObtenerExamenComplementario() 
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

            List<ExamenComplementario> listaExamenes = new List<ExamenComplementario>
            {
                new ExamenComplementario
                {
                    Detalle = "Examen_1",
                    FechaExamen = DateTime.Now,
                    Id = 25,
                    Paciente = paciente,
                    TipoExamen = "Complementario"
                },

                new ExamenComplementario
                {
                    Detalle = "Examen_2",
                    FechaExamen = DateTime.Now,
                    Id = 26,
                    Paciente = paciente,
                    TipoExamen = "Complementario_1"
                },

                new ExamenComplementario
                {
                    Detalle = "Examen_3",
                    FechaExamen = DateTime.Now,
                    Id = 27,
                    Paciente = paciente,
                    TipoExamen = "Complementario_2"
                }
            };

            List<ExamenComplementario> listaExamenesComplementariosClonados = new List<ExamenComplementario>();
            foreach (ExamenComplementario e in listaExamenes)
            {
                listaExamenesComplementariosClonados.Add(CloningService.Clone(e));
            }

            _autoMoquer.GetMock<IExamenComplementarioRepository>().Setup(e => e.Get()).Returns(listaExamenesComplementariosClonados);
            var result = _examenComplementarioLogic.Get();

            Assert.True(result != null);
            Assert.Equal(listaExamenes.Count, result.Count());
        }
    }
}
