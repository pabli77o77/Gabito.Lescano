using AdSanare.Validation;
using NUnit.Framework;
using FluentValidation.TestHelper;
using AdSanare.Entities;
using System;


namespace AdSanare.Validator.Tests
{
    [TestFixture]
    public class ExamenComplementarioValidatorTest
    {
        private ExamenComplementarioValidator _validador;

        [SetUp]
        public void Setup()
        {
            _validador = new ExamenComplementarioValidator();
        }

        [Test]
        public void Devuelve_error_fechaIngreso_vacia()
        {
            ExamenComplementario examen = new ExamenComplementario { FechaExamen = Convert.ToDateTime(null) };
            var result = _validador.TestValidate(examen);
            result.ShouldHaveValidationErrorFor(e => e.FechaExamen);
        }

        [Test]
        public void Devuelve_error_fechaIngreso_posterior_a_hoy()
        {
            ExamenComplementario examen = new ExamenComplementario { FechaExamen = Convert.ToDateTime(DateTime.Now.AddDays(2)) };
            var result = _validador.TestValidate(examen);
            result.ShouldHaveValidationErrorFor(e => e.FechaExamen);
        }

        [Test]
        public void Devuelve_error_tipo_examen_vacio()
        {
            ExamenComplementario examen = new ExamenComplementario { TipoExamen = string.Empty };
            var result = _validador.TestValidate(examen);
            result.ShouldHaveValidationErrorFor(e => e.TipoExamen);
        }

        [Test]
        public void Devuelve_error_tipo_examen_cantidad_minima_caracteres()
        {
            ExamenComplementario examen = new ExamenComplementario { TipoExamen = "a" };
            var result = _validador.TestValidate(examen);
            result.ShouldHaveValidationErrorFor(e => e.TipoExamen);
        }

        [Test]
        public void Devuelve_error_tipo_examen_cantidad_maxima_caracteres()
        {
            ExamenComplementario examen = new ExamenComplementario { TipoExamen = "u.ht=_$jdNwg6Ke&#x3TN}@9{kRAp7_tg&YYTmm%+R]Dd(Up!k]a.5,+EMB$66e5S-qh4G$WM!an(.A)j89tg!?x/mETezS!r([2MjGT6cC@PC/S_UP[jh,[uAdjGvMzzbfx4f28{+?XDvEenE:wBGbVV#%$4D=x],2BfvwJpg)vX//8dLM+8rVU%Aap+%?fL}(@_r]:.]NwiNFit4" };
            var result = _validador.TestValidate(examen);
            result.ShouldHaveValidationErrorFor(e => e.TipoExamen);
        }

        [Test]
        public void Devuelve_error_detalle_vacio()
        {
            ExamenComplementario examen = new ExamenComplementario { Detalle = string.Empty };
            var result = _validador.TestValidate(examen);
            result.ShouldHaveValidationErrorFor(e => e.Detalle);
        }

        [Test]
        public void Devuelve_error_detalle_cantidad_minima_caracteres()
        {
            ExamenComplementario examen = new ExamenComplementario { Detalle = "a" };
            var result = _validador.TestValidate(examen);
            result.ShouldHaveValidationErrorFor(e => e.Detalle);
        }

        [Test]
        public void Devuelve_error_detalle_cantidad_maxima_caracteres()
        {
            ExamenComplementario examen = new ExamenComplementario { Detalle = "u.ht=_$jdNwg6Ke&#x3TN}@9{kRAp7_tg&YYTmm%+R]Dd(Up!k]a.5,+EMB$66e5S-qh4G$WM!an(.A)j89tg!?x/mETezS!r([2MjGT6cC@PC/S_UP[jh,[uAdjGvMzzbfx4f28{+?XDvEenE:wBGbVV#%$4D=x],2BfvwJpg)vX//8dLM+8rVU%Aap+%?fL}(@_r]:.]NwiNFit4" };
            var result = _validador.TestValidate(examen);
            result.ShouldHaveValidationErrorFor(e => e.Detalle);
        }
    }
}
