using AdSanare.Entities;
using FluentValidation;
using System;

namespace AdSanare.Validation
{
    public class PersonaValidator:AbstractValidator<Persona>
    {
        public PersonaValidator()
        {
            RuleFor(p => p.Nombre)
                .NotNull().WithMessage("Debe Ingresar el Nombre")
                .Length(3,100).WithMessage("Debe ingresar entre {MinLength} y {MaxLength} caracteres.");
            RuleFor(p => p.Apellido)
                .NotNull().WithMessage("Debe Ingresar el Apellido")
                .Length(3, 100).WithMessage("Debe ingresar entre {MinLength} y {MaxLength} caracteres.");
            RuleFor(p => p.Documento)
                .NotNull().WithMessage("Debe Ingresar el Documento")
                .Length(6, 9).WithMessage("Debe ingresar entre {MinLength} y {MaxLength} caracteres.");
            RuleFor(p => p.ObraSocial)
                .NotNull().WithMessage("Debe Ingresar el nombre de la Obra Social")
                .Length(3, 100).WithMessage("Debe ingresar entre {MinLength} y {MaxLength} caracteres.");
            RuleFor(p => p.ObraSocialNumero)
                .NotNull().WithMessage("Debe Ingresar el numero de Afiliado de la Obra Social")
                .Length(6, 10).WithMessage("Debe ingresar entre {MinLength} y {MaxLength} caracteres.");
            RuleFor(p => p.Diagnostico)
                .NotNull().WithMessage("Debe Ingresar el Diagnóstico del Paciente")
                .Length(10, 200).WithMessage("Debe ingresar entre {MinLength} y {MaxLength} caracteres.");
            RuleFor(x => x.FechaNacimiento)
                .NotEmpty().WithMessage("Debe seleccionar una Fecha de Nacimiento")
                .LessThan(x => DateTime.Now.AddDays(1)).WithMessage("La Fecha ingresada no puede ser mayor a la de Hoy.");
        }
    }
}