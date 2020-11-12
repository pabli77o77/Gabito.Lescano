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
    public class UsuarioLogicTest
    {
        private readonly AutoMoqer _autoMoquer;
        private readonly IUsuarioLogic _usuarioLogic;

        public UsuarioLogicTest()
        {
            _autoMoquer = new AutoMoqer();
            _usuarioLogic = _autoMoquer.Resolve<UsuarioLogic>();
            _autoMoquer.GetMock<IUserUnitOfWork>().Setup(u => u.Usuarios).Returns(_autoMoquer.GetMock<IUsuarioRepository>().Object);
        }

        [Fact]
        public void ObtenerUsuarioPorId()
        {
            Usuario usr = new Usuario
            {
                Name = "TEST",
                LastName = "LastTest",
                Id = "idMockUser",
                UserName = "UserTest"
            };

            Usuario user = usr;
            _autoMoquer.GetMock<IUsuarioRepository>().Setup(u => u.Get(usr.Id)).Returns(user);

            var result = _usuarioLogic.Get(usr.Id);
            Assert.Equal(usr.Id, result.Id);
        }

        [Fact]
        public void ObtenerListaUsuarios()
        {
            List<Usuario> listaUsuarios = new List<Usuario>()
            {
                new Usuario
                {
                    Name = "TEST",
                    LastName = "LastTest",
                    Id = "idMockUser",
                    UserName = "UserTest"
                },

                new Usuario
                {
                    Name = "TEST_1",
                    LastName = "LastTest_1",
                    Id = "idMockUser_1",
                    UserName = "UserTest_1"
                },

                new Usuario
                {
                    Name = "TEST_2",
                    LastName = "LastTest_2",
                    Id = "idMockUser_2",
                    UserName = "UserTest_2"
                }
            };

            _autoMoquer.GetMock<IUsuarioRepository>().Setup(o => o.Get()).Returns(listaUsuarios);
            var result = _usuarioLogic.Get();

            Assert.True(result != null);
            Assert.Equal(listaUsuarios.Count, result.Count());
        }
    }
}
