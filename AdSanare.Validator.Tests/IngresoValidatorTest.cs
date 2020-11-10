using AdSanare.Validation;
using NUnit.Framework;
using FluentValidation.TestHelper;
using AdSanare.Entities;
using System;

namespace AdSanare.Validator.Tests
{
    [TestFixture]
    public class IngresoValidatorTest
    {
        private IngresoValidator _validador;

        [SetUp]
        public void Setup()
        {
            _validador = new IngresoValidator();
        }

        [Test]
        public void Devuelve_error_fechaIngreso_vacia()
        {
            Ingreso ingreso = new Ingreso { FechaIngreso = Convert.ToDateTime(null) };
            var result = _validador.TestValidate(ingreso);
            result.ShouldHaveValidationErrorFor(i => i.FechaIngreso);
        }

        [Test]
        public void Devuelve_error_fechaIngreso_posterior_a_hoy()
        {
            Ingreso ingreso = new Ingreso { FechaIngreso = Convert.ToDateTime(DateTime.Now.AddDays(2)) };
            var result = _validador.TestValidate(ingreso);
            result.ShouldHaveValidationErrorFor(i => i.FechaIngreso);
        }

        [Test]
        public void Devuelve_error_diagnositco_vacio()
        {
            Ingreso ingreso = new Ingreso { Diagnostico = string.Empty };
            var result = _validador.TestValidate(ingreso);
            result.ShouldHaveValidationErrorFor(i => i.Diagnostico);
        }

        [Test]
        public void Devuelve_error_diagnositco_cantidad_minima_caracteres()
        {
            Ingreso ingreso = new Ingreso { Diagnostico = "a" };
            var result = _validador.TestValidate(ingreso);
            result.ShouldHaveValidationErrorFor(i => i.Diagnostico);
        }

        [Test]
        public void Devuelve_error_diagnositco_cantidad_maxima_caracteres()
        {
            Ingreso ingreso = new Ingreso { Diagnostico = "u.ht=_$jdNwg6Ke&#x3TN}@9{kRAp7_tg&YYTmm%+R]Dd(Up!k]a.5,+EMB$66e5S-qh4G$WM!an(.A)j89tg!?x/mETezS!r([2MjGT6cC@PC/S_UP[jh,[uAdjGvMzzbfx4f28{+?XDvEenE:wBGbVV#%$4D=x],2BfvwJpg)vX//8dLM+8rVU%Aap+%?fL}(@_r]:.]NwiNFit4" };
            var result = _validador.TestValidate(ingreso);
            result.ShouldHaveValidationErrorFor(i => i.Diagnostico);
        }

        [Test]
        public void Devuelve_error_antecedentes_medicos_nulo()
        {
            Ingreso ingreso = new Ingreso { AntecedentesMedicos = null };
            var result = _validador.TestValidate(ingreso);
            result.ShouldHaveValidationErrorFor(i => i.AntecedentesMedicos);
        }

        [Test]
        public void Devuelve_error_antecedentes_medicos_cantidad_minima_caracteres()
        {
            Ingreso ingreso = new Ingreso { AntecedentesMedicos = "a" };
            var result = _validador.TestValidate(ingreso);
            result.ShouldHaveValidationErrorFor(i => i.AntecedentesMedicos);
        }

        [Test]
        public void Devuelve_error_antecedentes_medicos_cantidad_maxima_caracteres()
        {
            Ingreso ingreso = new Ingreso { AntecedentesMedicos = "u.ht=_$jdNwg6Ke&#x3TN}@9{kRAp7_tg&YYTmm%+R]Dd(Up!k]a.5,+EMB$66e5S-qh4G$WM!an(.A)j89tg!?x/mETezS!r([2MjGT6cC@PC/S_UP[jh,[uAdjGvMzzbfx4f28{+?XDvEenE:wBGbVV#%$4D=x],2BfvwJpg)vX//8dLM+8rVU%Aap+%?fL}(@_r]:.]NwiNFit4" };
            var result = _validador.TestValidate(ingreso);
            result.ShouldHaveValidationErrorFor(i => i.AntecedentesMedicos);
        }

        [Test]
        public void Devuelve_error_antecedentes_quirurgicos_nulo()
        {
            Ingreso ingreso = new Ingreso { AntecedentesQuirurgicos = null };
            var result = _validador.TestValidate(ingreso);
            result.ShouldHaveValidationErrorFor(i => i.AntecedentesQuirurgicos);
        }

        [Test]
        public void Devuelve_error_antecedentes_quirurgicos_cantidad_minima_caracteres()
        {
            Ingreso ingreso = new Ingreso { AntecedentesQuirurgicos = "a" };
            var result = _validador.TestValidate(ingreso);
            result.ShouldHaveValidationErrorFor(i => i.AntecedentesQuirurgicos);
        }

        [Test]
        public void Devuelve_error_antecedentes_quirurgicos_cantidad_maxima_caracteres()
        {
            Ingreso ingreso = new Ingreso { AntecedentesQuirurgicos = "u.ht=_$jdNwg6Ke&#x3TN}@9{kRAp7_tg&YYTmm%+R]Dd(Up!k]a.5,+EMB$66e5S-qh4G$WM!an(.A)j89tg!?x/mETezS!r([2MjGT6cC@PC/S_UP[jh,[uAdjGvMzzbfx4f28{+?XDvEenE:wBGbVV#%$4D=x],2BfvwJpg)vX//8dLM+8rVU%Aap+%?fL}(@_r]:.]NwiNFit4" };
            var result = _validador.TestValidate(ingreso);
            result.ShouldHaveValidationErrorFor(i => i.AntecedentesQuirurgicos);
        }

        [Test]
        public void Devuelve_error_alergias_nulo()
        {
            Ingreso ingreso = new Ingreso { Alergias = null };
            var result = _validador.TestValidate(ingreso);
            result.ShouldHaveValidationErrorFor(i => i.Alergias);
        }

        [Test]
        public void Devuelve_error_alergias_cantidad_minima_caracteres()
        {
            Ingreso ingreso = new Ingreso { Alergias = "a" };
            var result = _validador.TestValidate(ingreso);
            result.ShouldHaveValidationErrorFor(i => i.Alergias);
        }

        [Test]
        public void Devuelve_error_alergias_cantidad_maxima_caracteres()
        {
            Ingreso ingreso = new Ingreso { Alergias = "u.ht=_$jdNwg6Ke&#x3TN}@9{kRAp7_tg&YYTmm%+R]Dd(Up!k]a.5,+EMB$66e5S-qh4G$WM!an(.A)j89tg!?x/mETezS!r([2MjGT6cC@PC/S_UP[jh,[uAdjGvMzzbfx4f28{+?XDvEenE:wBGbVV#%$4D=x],2BfvwJpg)vX//8dLM+8rVU%Aap+%?fL}(@_r]:.]NwiNFit4" };
            var result = _validador.TestValidate(ingreso);
            result.ShouldHaveValidationErrorFor(i => i.Alergias);
        }

        [Test]
        public void Devuelve_error_medicacion_habitual_nulo()
        {
            Ingreso ingreso = new Ingreso { MedicacionHabitual = null };
            var result = _validador.TestValidate(ingreso);
            result.ShouldHaveValidationErrorFor(i => i.MedicacionHabitual);
        }

        [Test]
        public void Devuelve_error_medicacion_habitual_cantidad_minima_caracteres()
        {
            Ingreso ingreso = new Ingreso { MedicacionHabitual = "a" };
            var result = _validador.TestValidate(ingreso);
            result.ShouldHaveValidationErrorFor(i => i.MedicacionHabitual);
        }

        [Test]
        public void Devuelve_error_medicacion_habitual_cantidad_maxima_caracteres()
        {
            Ingreso ingreso = new Ingreso { MedicacionHabitual = "u.ht=_$jdNwg6Ke&#x3TN}@9{kRAp7_tg&YYTmm%+R]Dd(Up!k]a.5,+EMB$66e5S-qh4G$WM!an(.A)j89tg!?x/mETezS!r([2MjGT6cC@PC/S_UP[jh,[uAdjGvMzzbfx4f28{+?XDvEenE:wBGbVV#%$4D=x],2BfvwJpg)vX//8dLM+8rVU%Aap+%?fL}(@_r]:.]NwiNFit4" };
            var result = _validador.TestValidate(ingreso);
            result.ShouldHaveValidationErrorFor(i => i.MedicacionHabitual);
        }

        [Test]
        public void Devuelve_error_peso_vacio()
        {
            Ingreso ingreso = new Ingreso();
            var result = _validador.TestValidate(ingreso);
            result.ShouldHaveValidationErrorFor(i => i.Peso);
        }

        [Test]
        public void Devuelve_error_talla_vacia()
        {
            Ingreso ingreso = new Ingreso();
            var result = _validador.TestValidate(ingreso);
            result.ShouldHaveValidationErrorFor(i => i.Talla);
        }
    }
}
