using AdSanare.Context;
using AdSanare.Core.Helper;
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

            Cama camaClon = CloningService.Clone(cama);

            _autoMoquer.GetMock<ICamaRepository>().Setup(c => c.Get(idCama)).Returns(camaClon);

            var result = _camaLogic.Get(idCama);
            Assert.Equal(cama.Id, result.Id);
            Assert.Equal(cama.Descripcion, result.Descripcion);
            Assert.Equal(cama.ServicioInternacion.Id, result.ServicioInternacion.Id);
            Assert.Equal(cama.ServicioInternacion.Descripcion, result.ServicioInternacion.Descripcion);
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

            List<Cama> listaCamasClonadas = new List<Cama>();
            foreach (Cama c in listaCamas)
            {
                listaCamasClonadas.Add(CloningService.Clone(c));
            }

            _autoMoquer.GetMock<ICamaRepository>().Setup(c => c.Get()).Returns(listaCamasClonadas);
            var result = _camaLogic.Get();

            Assert.True(result != null);
            Assert.Equal(listaCamas.Count, result.Count());
        }
    }
}
