using AdSanare.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdSanare.Validation
{
    public class ExamenComplementarioValidator:AbstractValidator<ExamenComplementario>
    {
        public ExamenComplementarioValidator()
        {
            RuleFor(x => x.Paciente.Documento)
                .NotNull().When(x => x.Paciente != null).WithMessage("Debe ingresar un Paciente");
            RuleFor(x => x.FechaExamen)
                .NotEmpty().WithMessage("Debe seleccionar una Fecha de Examen")
                .LessThan(x => DateTime.Now.AddDays(1)).WithMessage("La Fecha ingresada no puede ser mayor a la de Hoy.");
            RuleFor(p => p.TipoExamen)
                .NotNull().WithMessage("Debe Ingresar el Tipo de Examen")
                .Length(3, 50).WithMessage("Debe ingresar entre {MinLength} y {MaxLength} caracteres.");
            RuleFor(p => p.Detalle)
                .NotNull().WithMessage("Debe Ingresar el Detalle")
                .Length(5, 200).WithMessage("Debe ingresar entre {MinLength} y {MaxLength} caracteres.");
        }
    }
}
