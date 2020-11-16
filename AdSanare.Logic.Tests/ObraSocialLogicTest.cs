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
    public class ObraSocialLogicTest
    {
        private readonly AutoMoqer _autoMoquer;
        private readonly IObraSocialLogic _obraSocialLogic;

        public ObraSocialLogicTest()
        {
            _autoMoquer = new AutoMoqer();
            _obraSocialLogic = _autoMoquer.Resolve<ObraSocialLogic>();
            _autoMoquer.GetMock<IUnitOfWork>().Setup(o => o.ObrasSociales).Returns(_autoMoquer.GetMock<IObraSocialRepository>().Object);
        }

        [Fact]
        public void ObtenerObraSocialId() 
        {
            ObraSocial os = new ObraSocial()
            {
                BajaLogica = false,
                Descripcion = "Omint",
                Id = 1
            };

            ObraSocial obraSocialClonada = CloningService.Clone(os);

            _autoMoquer.GetMock<IObraSocialRepository>().Setup(i => i.Get(os.Id)).Returns(obraSocialClonada);

            var result = _obraSocialLogic.Get(os.Id);
            Assert.Equal(os.Id, result.Id);
        }

        [Fact]
        public void ObtenerListaObraSocial() 
        {
            List<ObraSocial> lsObraSocial = new List<ObraSocial>()
            {
                new ObraSocial()
                {
                    BajaLogica = false,
                    Descripcion = "Omint",
                    Id = 1
                },
                new ObraSocial()
                {
                    BajaLogica = false,
                    Descripcion = "Osde",
                    Id = 2
                },
                new ObraSocial()
                {
                    BajaLogica = false,
                    Descripcion = "Swiss Medical",
                    Id = 3
                }
            };

            List<ObraSocial> listaObrasSocialesClonados = new List<ObraSocial>();
            foreach (ObraSocial s in lsObraSocial)
            {
                listaObrasSocialesClonados.Add(CloningService.Clone(s));
            }

            _autoMoquer.GetMock<IObraSocialRepository>().Setup(o => o.Get()).Returns(listaObrasSocialesClonados);
            var result = _obraSocialLogic.Get();

            Assert.True(result != null);
            Assert.Equal(lsObraSocial.Count, result.Count());
        }
    }
}
