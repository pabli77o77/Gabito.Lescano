using AdSanare.Context;
using AdSanare.Entities;
using AdSanare.Logic.Interfaces;
using AdSanare.Repository.Interfaces;
using AdSanare.UOW.Interfaces;
using AutoMoqCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Xunit;

namespace AdSanare.Logic.Tests
{
    public class CamaLogicTest
    {
        private readonly AutoMoqer _autoMoquer;
        private readonly ICamaLogic _camaLogic;

        public CamaLogicTest()
        {
            _autoMoquer = new AutoMoqer();
            _camaLogic = _autoMoquer.Resolve<CamaLogic>();
            _autoMoquer.GetMock<IUnitOfWork>().Setup(m => m.Camas).Returns(_autoMoquer.GetMock<ICamaRepository>().Object);

        }

        [Fact]
        public void ObtieneCamaPorId() 
        {
            int idCama = 2;

            Servicio servicio1 = new Servicio
            {
                Id = 1,
                Descripcion = "Internación"
            };

            Cama cama = new Cama
            {
                Id = idCama,
                Descripcion = "202",
                ServicioInternacion = servicio1
            };

            Cama camaTest = cama;
            _autoMoquer.GetMock<ICamaRepository>().Setup(c => c.Get(idCama)).Returns(camaTest);

            var result = _camaLogic.Get(idCama);
            Assert.Equal(cama.Id, result.Id);
            Assert.Equal(cama.Descripcion, result.Descripcion);
            Assert.Equal(cama.ServicioInternacion, result.ServicioInternacion);
        }

        [Fact]
        public void ObtieneListaCamas() 
        {
            Servicio servicio1 = new Servicio
            {
                Id = 1,
                Descripcion = "Internación"
            };

            List<Cama> listaCamas = new List<Cama>()
            {
                
                new Cama
                {
                    Id = 1,
                    Descripcion = "Internacion",
                    ServicioInternacion = servicio1
                },

                new Cama
                {
                    Id = 2,
                    Descripcion = "Internacion2",
                    ServicioInternacion = servicio1
                },

                new Cama
                {
                    Id = 3,
                    Descripcion = "Internacion3",
                    ServicioInternacion = servicio1
                }
            };

            _autoMoquer.GetMock<ICamaRepository>().Setup(c => c.Get()).Returns(listaCamas);
            var result = _camaLogic.Get();

            Assert.True(result != null);
            Assert.Equal(listaCamas.Count, result.Count());
        }
    }
}
