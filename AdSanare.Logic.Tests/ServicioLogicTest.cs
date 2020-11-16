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
    public class ServicioLogicTest
    {
        private readonly AutoMoqer _autoMoquer;
        private readonly IServicioLogic _servicioLogic;

        public ServicioLogicTest()
        {
            _autoMoquer = new AutoMoqer();
            _servicioLogic = _autoMoquer.Resolve<ServicioLogic>();
            _autoMoquer.GetMock<IUnitOfWork>().Setup(s => s.Servicios).Returns(_autoMoquer.GetMock<IServicioRepository>().Object);

        }

        [Fact]
        public void ObtieneServicioPorId()
        {
            int idServicio = 56;

            Servicio servicio = new Servicio
            {
                Descripcion = "Internación",
                Id = idServicio
            };

            Servicio servicioClonado = CloningService.Clone(servicio);

            _autoMoquer.GetMock<IServicioRepository>().Setup(s => s.Get(idServicio)).Returns(servicioClonado);
            var result = _servicioLogic.Get(idServicio);
            Assert.Equal(servicio.Id, result.Id);
            Assert.Equal(servicio.Descripcion, result.Descripcion);
        }

        [Fact]
        public void ObtieneServicio()
        {
            List<Servicio> listaServicios = new List<Servicio>
            {
                new Servicio
                {
                    Descripcion = "Internación",
                    Id = 10
                },

                new Servicio
                {
                    Descripcion = "Cirugía",
                    Id = 21
                },

                new Servicio
                {
                    Descripcion = "Terapia intensiva",
                    Id = 34
                }
            };

            List<Servicio> listaServiciosClonados = new List<Servicio>();
            foreach (Servicio s in listaServicios)
            {
                listaServiciosClonados.Add(CloningService.Clone(s));
            }

            _autoMoquer.GetMock<IServicioRepository>().Setup(s => s.Get()).Returns(listaServiciosClonados);
            var result = _servicioLogic.Get();

            Assert.True(result != null);
            Assert.Equal(listaServicios.Count, result.Count());
        }
    }
}
