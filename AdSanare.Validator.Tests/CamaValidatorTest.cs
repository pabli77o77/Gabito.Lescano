using AdSanare.Entities;
using AdSanare.Validation;
using NUnit.Framework;
using FluentValidation.TestHelper;

namespace AdSanare.Validator.Tests
{
    [TestFixture]
    public class CamaValidatorTest
    {
        private CamaValidator _validador;

        [SetUp]
        public void Setup()
        {
            _validador = new CamaValidator();
        }

        [Test]
        public void Devuelve_error_descripcion_nula() 
        {
            Cama cama = new Cama { Descripcion = null };
            var result = _validador.TestValidate(cama);
            result.ShouldHaveValidationErrorFor(c => c.Descripcion);
        }

        [Test]
        public void Devuelve_error_descripcion_cantidad_caracteres() 
        {
            Cama cama = new Cama { Descripcion = "asasasas1223" };
            var result = _validador.TestValidate(cama);
            result.ShouldHaveValidationErrorFor(c => c.Descripcion);
        }
    }
}
