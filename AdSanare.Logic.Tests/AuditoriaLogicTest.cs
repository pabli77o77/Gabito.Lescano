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
    public class AuditoriaLogicTest
    {
        private readonly AutoMoqer _autoMoquer;
        private readonly IAuditoriaLogic _auditoriaLogic;

        public AuditoriaLogicTest()
        {
            _autoMoquer = new AutoMoqer();
            _auditoriaLogic = _autoMoquer.Resolve<AuditoriaLogic>();
            _autoMoquer.GetMock<IUserUnitOfWork>().Setup(a => a.Auditorias).Returns(_autoMoquer.GetMock<IAuditoriaRepository>().Object);
        }

        [Fact]
        public void ObtenerAuditoriaPorId() 
        {
            Usuario usr = new Usuario
            {
                Name = "TEST",
                LastName = "LastTest",
                Id = "idMockUser",
                UserName = "UserTest"
            };

            Auditoria auditoria = new Auditoria
            { 
                Id = 1,
                Entidad = "Entidad",
                EntidadId = 1,
                TipoEntidad = "TipoEntidad",
                FechaRegistro = DateTime.Now,
                Usuario = usr
            };

            Auditoria aud1 = auditoria;
            _autoMoquer.GetMock<IAuditoriaRepository>().Setup(i => i.Get(auditoria.Id)).Returns(aud1);

            var result = _auditoriaLogic.Get(auditoria.Id);
            Assert.Equal(auditoria.Id, result.Id);
            Assert.Equal(auditoria.Entidad, result.Entidad);
            Assert.Equal(auditoria.EntidadId, result.EntidadId);
            Assert.Equal(auditoria.FechaRegistro, result.FechaRegistro);
            Assert.Equal(auditoria.TipoEntidad, result.TipoEntidad);
            Assert.Equal(auditoria.Usuario, result.Usuario);
        }

        [Fact]
        public void ObtenerListAuditorias()
        {
            Usuario usr = new Usuario
            {
                Name = "TEST",
                LastName = "LastTest",
                Id = "idMockUser",
                UserName = "UserTest"
            };

            List<Auditoria> listaAuditorias = new List<Auditoria>()
            {
                new Auditoria
                {
                    Id = 1,
                    Entidad = "Entidad",
                    EntidadId = 1,
                    TipoEntidad = "TipoEntidad",
                    FechaRegistro = DateTime.Now,
                    Usuario = usr
                },

                new Auditoria
                {
                    Id = 2,
                    Entidad = "Entidad_2",
                    EntidadId = 2,
                    TipoEntidad = "TipoEntidad_2",
                    FechaRegistro = DateTime.Now,
                    Usuario = usr
                },

                new Auditoria
                {
                    Id = 3,
                    Entidad = "Entidad_3",
                    EntidadId = 3,
                    TipoEntidad = "TipoEntidad_3",
                    FechaRegistro = DateTime.Now,
                    Usuario = usr
                }
            };
            _autoMoquer.GetMock<IAuditoriaRepository>().Setup(i => i.Get()).Returns(listaAuditorias);
            var result = _auditoriaLogic.Get();

            Assert.True(result != null);
            Assert.Equal(listaAuditorias.Count, result.Count());
        }

    }
}
