using NUnit.Framework;
using FluentValidation.TestHelper;
using AdSanare.Validation;
using AdSanare.Entities;
using System;

namespace AdSanare.Validator.Tests
{
    [TestFixture]
    public class PacienteValidatorTest
    {
        private PacienteValidator _validador;
        
        [SetUp]
        public void Setup()
        {
            _validador = new PacienteValidator();
        }
        [Test]
        public void Devuelve_error_nombre_nulo()
        {
            Paciente paciente = new Paciente { Nombre = null };
            var result = _validador.TestValidate(paciente);
            result.ShouldHaveValidationErrorFor(p => p.Nombre);
        }
        [Test]
        public void Devuelve_error_nombre_cantidad_caracteres()
        {
            Paciente paciente = new Paciente { Nombre = "as" };
            var result = _validador.TestValidate(paciente);
            result.ShouldHaveValidationErrorFor(p => p.Nombre);
        }
        [Test]
        public void Devuelve_error_apellido_nulo()
        {
            Paciente paciente = new Paciente { Apellido = null };
            var result = _validador.TestValidate(paciente);
            result.ShouldHaveValidationErrorFor(p => p.Apellido);
        }
        [Test]
        public void Devuelve_error_apellido_cantidad_caracteres()
        {
            Paciente paciente = new Paciente { Apellido = "as" };
            var result = _validador.TestValidate(paciente);
            result.ShouldHaveValidationErrorFor(p => p.Apellido);
        }
        [Test]
        public void Devuelve_error_Numero_Documento_nulo()
        {
            Paciente paciente = new Paciente { Documento = null };
            var result = _validador.TestValidate(paciente);
            result.ShouldHaveValidationErrorFor(p => p.Documento);
        }
        [Test]
        public void Devuelve_error_Numero_Documento_minima_cantidad_caracteres()
        {
            Paciente paciente = new Paciente { Documento = "11223" };
            var result = _validador.TestValidate(paciente);
            result.ShouldHaveValidationErrorFor(p => p.Documento);
        }
        [Test]
        public void Devuelve_error_Numero_Documento_maxima_cantidad_caracteres()
        {
            Paciente paciente = new Paciente { Documento = "12345678987" };
            var result = _validador.TestValidate(paciente);
            result.ShouldHaveValidationErrorFor(p => p.Documento);
        }
        [Test]
        public void Devuelve_error_sexo_nulo()
        {
            Paciente paciente = new Paciente { Sexo = null };
            var result = _validador.TestValidate(paciente);
            result.ShouldHaveValidationErrorFor(p => p.Sexo);
        }
        [Test]
        public void Devuelve_error_sexo_cantidad_caracteres()
        {
            Paciente paciente = new Paciente { Sexo = "asdasdasdasdsdaasdasdasdasdasdasdasdsdaasdasdasdasdasdasdasdasdasdasdasdasdasdasdasd" };
            var result = _validador.TestValidate(paciente);
            result.ShouldHaveValidationErrorFor(p => p.Sexo);
        }
        [Test]
        public void Devuelve_error_estado_civil_nulo()
        {
            Paciente paciente = new Paciente { EstadoCivil = null };
            var result = _validador.TestValidate(paciente);
            result.ShouldHaveValidationErrorFor(p => p.EstadoCivil);
        }
        [Test]
        public void Devuelve_error_estado_civil_cantidad_caracteres()
        {
            Paciente paciente = new Paciente { EstadoCivil = "asdasdasdasdsasdasdasdadsaasdasdasddasasddasdsasdadssdasdasdasdasdasdasdasddasasdasdasddasasdasdasdasdasd" };
            var result = _validador.TestValidate(paciente);
            result.ShouldHaveValidationErrorFor(p => p.EstadoCivil);
        }
        [Test]
        public void Devuelve_error_Numero_Obra_Social_nulo()
        {
            Paciente paciente = new Paciente { ObraSocialNumero = null };
            var result = _validador.TestValidate(paciente);
            result.ShouldHaveValidationErrorFor(p => p.ObraSocialNumero);
        }
        [Test]
        public void Devuelve_error_Numero_Obra_Social_minima_cantidad_caracteres()
        {
            Paciente paciente = new Paciente { ObraSocialNumero = "11223" };
            var result = _validador.TestValidate(paciente);
            result.ShouldHaveValidationErrorFor(p => p.ObraSocialNumero);
        }
        [Test]
        public void Devuelve_error_Numero_Obra_Social_maxima_cantidad_caracteres()
        {
            Paciente paciente = new Paciente { ObraSocialNumero = "12345678987" };
            var result = _validador.TestValidate(paciente);
            result.ShouldHaveValidationErrorFor(p => p.ObraSocialNumero);
        }
        [Test]
        public void Devuelve_error_Telefono_nulo()
        {
            Paciente paciente = new Paciente { Telefono = null };
            var result = _validador.TestValidate(paciente);
            result.ShouldHaveValidationErrorFor(p => p.Telefono);
        }
        [Test]
        public void Devuelve_error_Telefono_minima_cantidad_caracteres()
        {
            Paciente paciente = new Paciente { Telefono = "11223" };
            var result = _validador.TestValidate(paciente);
            result.ShouldHaveValidationErrorFor(p => p.Telefono);
        }
        [Test]
        public void Devuelve_error_Telefono_maxima_cantidad_caracteres()
        {
            Paciente paciente = new Paciente { Telefono = "123456789987654321" };
            var result = _validador.TestValidate(paciente);
            result.ShouldHaveValidationErrorFor(p => p.Telefono);
        }
        [Test]
        public void Devuelve_error_Fecha_Nacimiento_vacio()
        {
            Paciente paciente = new Paciente { FechaNacimiento = Convert.ToDateTime("01-01-0001") };
            var result = _validador.TestValidate(paciente);
            result.ShouldHaveValidationErrorFor(p => p.FechaNacimiento);
        }
        [Test]
        public void Devuelve_error_Fecha_Nacimiento_mayor_a_hoy()
        {
            Paciente paciente = new Paciente { FechaNacimiento = DateTime.Now.AddDays(2)};
            var result = _validador.TestValidate(paciente);
            result.ShouldHaveValidationErrorFor(p => p.FechaNacimiento);
        }
    }
}