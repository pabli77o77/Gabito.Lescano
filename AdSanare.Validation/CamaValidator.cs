using AdSanare.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdSanare.Validation
{
    public class CamaValidator:AbstractValidator<Cama>
    {
        public CamaValidator()
        {
            RuleFor(p => p.Descripcion)
                .NotNull().WithMessage("Debe Ingresar el Número/Letra de la Cama")
                .Length(1, 10).WithMessage("Debe ingresar entre {MinLength} y {MaxLength} caracteres.");
        }
    }
}
