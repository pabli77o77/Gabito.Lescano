using AdSanare.Validation;
using NUnit.Framework;
using FluentValidation.TestHelper;
using AdSanare.Entities;
using System;

namespace AdSanare.Validator.Tests
{
    [TestFixture]
    public class ServicioValidatorTest
    {
        private ServicioValidator _validador;

        [SetUp]
        public void Setup()
        {
            _validador = new ServicioValidator();
        }

        [Test]
        public void Devuelve_error_descripcion_vacio()
        {
            Servicio servicio = new Servicio { Descripcion = string.Empty };
            var result = _validador.TestValidate(servicio);
            result.ShouldHaveValidationErrorFor(s => s.Descripcion);
        }

        [Test]
        public void Devuelve_error_descripcion_cantidad_minima_caracteres()
        {
            Servicio servicio = new Servicio { Descripcion = "a" };
            var result = _validador.TestValidate(servicio);
            result.ShouldHaveValidationErrorFor(s => s.Descripcion);
        }

        [Test]
        public void Devuelve_error_descripcion_cantidad_maxima_caracteres()
        {
            Servicio servicio = new Servicio { Descripcion = "u.ht=_$jdNwg6Ke&#x3TN}@9{kRAp7_tg&YYTmm%+R]Dd(Up!k]a.5,+EMB$66e5S-qh4G$WM!an(.A)j89tg!?x/mETezS!r([2MjGT6cC@PC/S_UP[jh,[uAdjGvMzzbfx4f28{+?XDvEenE:wBGbVV#%$4D=x],2BfvwJpg)vX//8dLM+8rVU%Aap+%?fL}(@_r]:.]NwiNFit4" };
            var result = _validador.TestValidate(servicio);
            result.ShouldHaveValidationErrorFor(s => s.Descripcion);
        }
    }
}
