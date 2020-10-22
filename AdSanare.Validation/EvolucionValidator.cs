using AdSanare.Entities;
using FluentValidation;
using System;

namespace AdSanare.Validation
{
    public class EvolucionValidator:AbstractValidator<Evolucion>
    {
        public EvolucionValidator()
        {
            RuleFor(x => x.FechaEvolucion)
                .NotEmpty().WithMessage("Debe seleccionar una Fecha de Evolución")
                .LessThan(x => DateTime.Now.AddDays(1)).WithMessage("La Fecha ingresada no puede ser mayor a la de Hoy.");
            RuleFor(p => p.ServicioInternacion.Id)
                .NotNull().WithMessage("Debe seleccionar un Servicio");
            RuleFor(p => p.CamaInternacion.Id)
                .NotNull().WithMessage("Debe seleccionar una Cama");
            RuleFor(p => p.ExamenFisico).SetValidator(new ExamenFisicoValidator());
        }
    }
}
