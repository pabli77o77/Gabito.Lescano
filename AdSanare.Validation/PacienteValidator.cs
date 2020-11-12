using AdSanare.Entities;
using FluentValidation;
using System;

namespace AdSanare.Validation
{
    public class PacienteValidator:AbstractValidator<Paciente>
    {
        public PacienteValidator()
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
            RuleFor(x => x.FechaNacimiento)
                .NotEmpty().WithMessage("Debe seleccionar una Fecha de Nacimiento")
                .LessThan(x => DateTime.Now).WithMessage("La Fecha ingresada no puede ser mayor a la de Hoy.");
            RuleFor(p => p.Sexo)
                .NotNull().WithMessage("Debe Ingresar el Sexo del Paciente")
                .Length(1, 20).WithMessage("Debe ingresar entre {MinLength} y {MaxLength} caracteres.");
            RuleFor(p => p.EstadoCivil)
                .NotNull().WithMessage("Debe Ingresar el Estado Civil del Paciente")
                .Length(1, 30).WithMessage("Debe ingresar entre {MinLength} y {MaxLength} caracteres.");
            RuleFor(p => p.ObraSocialNumero)
                .NotNull().WithMessage("Debe Ingresar el numero de Afiliado de la Obra Social")
                .Length(6, 10).WithMessage("Debe ingresar entre {MinLength} y {MaxLength} caracteres.");
            RuleFor(p => p.Telefono)
                .NotNull().WithMessage("Debe Ingresar el numero de Teléfono del Paciente")
                .Length(7, 14).WithMessage("Debe ingresar entre {MinLength} y {MaxLength} caracteres.");
        }
    }
}