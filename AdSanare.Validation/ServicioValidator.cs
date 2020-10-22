using AdSanare.Entities;
using FluentValidation;

namespace AdSanare.Validation
{
    public class ServicioValidator:AbstractValidator<Servicio>
    {
        public ServicioValidator()
        {
            RuleFor(p => p.Descripcion)
                .NotNull().WithMessage("Debe Ingresar el Nombre del Servicio")
                .Length(3,100).WithMessage("Debe ingresar entre {MinLength} y {MaxLength} caracteres.");
        }
    }
}
