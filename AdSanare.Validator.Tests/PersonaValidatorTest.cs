using NUnit.Framework;
using FluentValidation;
using FluentValidation.TestHelper;
using AdSanare.Validation;
using AdSanare.Entities;
using System;

namespace AdSanare.Validator.Tests
{
    [TestFixture]
    public class PersonaValidatorTest
    {
        private PersonaValidator _validador;
        
        [SetUp]
        public void Setup()
        {
            _validador = new PersonaValidator();
        }
        [Test]
        public void Devuelve_error_nombre_nulo()
        {
            Persona persona = new Persona { Nombre = null };
            var result = _validador.TestValidate(persona);
            result.ShouldHaveValidationErrorFor(p => p.Nombre);
        }
        [Test]
        public void Devuelve_error_nombre_cantidad_caracteres()
        {
            Persona persona = new Persona { Nombre = "as" };
            var result = _validador.TestValidate(persona);
            result.ShouldHaveValidationErrorFor(p => p.Nombre);
        }
        [Test]
        public void Devuelve_error_apellido_nulo()
        {
            Persona persona = new Persona { Apellido = null };
            var result = _validador.TestValidate(persona);
            result.ShouldHaveValidationErrorFor(p => p.Apellido);
        }
        [Test]
        public void Devuelve_error_apellido_cantidad_caracteres()
        {
            Persona persona = new Persona { Apellido = "as" };
            var result = _validador.TestValidate(persona);
            result.ShouldHaveValidationErrorFor(p => p.Apellido);
        }
        [Test]
        public void Devuelve_error_Numero_Documento_nulo()
        {
            Persona persona = new Persona { Documento = null };
            var result = _validador.TestValidate(persona);
            result.ShouldHaveValidationErrorFor(p => p.Documento);
        }
        [Test]
        public void Devuelve_error_Numero_Documento_minima_cantidad_caracteres()
        {
            Persona persona = new Persona { Documento = "11223" };
            var result = _validador.TestValidate(persona);
            result.ShouldHaveValidationErrorFor(p => p.Documento);
        }
        [Test]
        public void Devuelve_error_Numero_Documento_maxima_cantidad_caracteres()
        {
            Persona persona = new Persona { Documento = "12345678987" };
            var result = _validador.TestValidate(persona);
            result.ShouldHaveValidationErrorFor(p => p.Documento);
        }
        [Test]
        public void Devuelve_error_obra_social_nulo()
        {
            Persona persona = new Persona { ObraSocial = null };
            var result = _validador.TestValidate(persona);
            result.ShouldHaveValidationErrorFor(p => p.ObraSocial);
        }
        [Test]
        public void Devuelve_error_obra_social_cantidad_caracteres()
        {
            Persona persona = new Persona { ObraSocial = "as" };
            var result = _validador.TestValidate(persona);
            result.ShouldHaveValidationErrorFor(p => p.ObraSocial);
        }
        [Test]
        public void Devuelve_error_Numero_Obra_Social_nulo()
        {
            Persona persona = new Persona { ObraSocialNumero = null };
            var result = _validador.TestValidate(persona);
            result.ShouldHaveValidationErrorFor(p => p.ObraSocialNumero);
        }
        [Test]
        public void Devuelve_error_Numero_Obra_Social_minima_cantidad_caracteres()
        {
            Persona persona = new Persona { ObraSocialNumero = "11223" };
            var result = _validador.TestValidate(persona);
            result.ShouldHaveValidationErrorFor(p => p.ObraSocialNumero);
        }
        [Test]
        public void Devuelve_error_Numero_Obra_Social_maxima_cantidad_caracteres()
        {
            Persona persona = new Persona { ObraSocialNumero = "12345678987" };
            var result = _validador.TestValidate(persona);
            result.ShouldHaveValidationErrorFor(p => p.ObraSocialNumero);
        }
        [Test]
        public void Devuelve_error_diagnostico_nulo()
        {
            Persona persona = new Persona { Diagnostico = null };
            var result = _validador.TestValidate(persona);
            result.ShouldHaveValidationErrorFor(p => p.Diagnostico);
        }
        [Test]
        public void Devuelve_error_diagnostico_cantidad_caracteres()
        {
            Persona persona = new Persona { Diagnostico = "Prueba" };
            var result = _validador.TestValidate(persona);
            result.ShouldHaveValidationErrorFor(p => p.Diagnostico);
        }
        [Test]
        public void Devuelve_error_Fecha_Nacimiento_vacio()
        {
            Persona persona = new Persona { FechaNacimiento = Convert.ToDateTime("01-01-0001") };
            var result = _validador.TestValidate(persona);
            result.ShouldHaveValidationErrorFor(p => p.FechaNacimiento);
        }
        [Test]
        public void Devuelve_error_Fecha_Nacimiento_mayor_a_hoy()
        {
            Persona persona = new Persona { FechaNacimiento = DateTime.Now.AddDays(2)};
            var result = _validador.TestValidate(persona);
            result.ShouldHaveValidationErrorFor(p => p.FechaNacimiento);
        }
    }
}