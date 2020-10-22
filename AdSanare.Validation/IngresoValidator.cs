using AdSanare.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdSanare.Validation
{
    public class IngresoValidator:AbstractValidator<Ingreso>
    {
        public IngresoValidator()
        {
            RuleFor(x => x.Paciente.Documento)
                .NotNull().When(x => x.Paciente != null).WithMessage("Debe ingresar un Paciente");
            RuleFor(x => x.FechaIngreso)
                .NotEmpty().WithMessage("Debe seleccionar una Fecha de Ingreso")
                .LessThan(x => DateTime.Now.AddDays(1)).WithMessage("La Fecha ingresada no puede ser mayor a la de Hoy.");
            RuleFor(p => p.Diagnostico)
                .NotNull().WithMessage("Debe Ingresar el Diagnostico")
                .Length(5, 200).WithMessage("Debe ingresar entre {MinLength} y {MaxLength} caracteres.");
            RuleFor(p => p.AntecedentesMedicos)
                .NotNull().WithMessage("Debe Ingresar los Antecedentes Medicos")
                .Length(5, 200).WithMessage("Debe ingresar entre {MinLength} y {MaxLength} caracteres.");
            RuleFor(p => p.AntecedentesQuirurgicos)
                .NotNull().WithMessage("Debe Ingresar los Antecedentes Quirurgicos")
                .Length(5, 200).WithMessage("Debe ingresar entre {MinLength} y {MaxLength} caracteres.");
            RuleFor(p => p.Alergias)
                .NotNull().WithMessage("Debe Ingresar si posee Alergias")
                .Length(5, 200).WithMessage("Debe ingresar entre {MinLength} y {MaxLength} caracteres.");
            RuleFor(p => p.MedicacionHabitual)
                .NotNull().WithMessage("Debe Ingresar la medicación que ingresa habitualmente")
                .Length(5, 200).WithMessage("Debe ingresar entre {MinLength} y {MaxLength} caracteres.");
            RuleFor(p => p.Peso)
                .NotEmpty().WithMessage("Debe Ingresar el Peso");
            RuleFor(p => p.Talla)
                .NotEmpty().WithMessage("Debe Ingresar la Talla");
        }
    }
}
