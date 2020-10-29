using AdSanare.Entities;
using FluentValidation;

namespace AdSanare.Validation
{
    public class ExamenFisicoValidator:AbstractValidator<ExamenFisico>
    {
        public ExamenFisicoValidator()
        {
            RuleFor(p => p.EstadoActual)
                .NotNull().WithMessage("Debe Ingresar el Estado Actual")
                .Length(3, 500).WithMessage("Debe ingresar entre {MinLength} y {MaxLength} caracteres.");
            RuleFor(p => p.FrecuenciaCardiaca)
                .NotEmpty().WithMessage("Debe Ingresar la Frecuencia Cardiaca")
                .InclusiveBetween(40, 130).WithMessage("Debe ingresar un valor entre {From} y {To}");
            RuleFor(p => p.TensionArterial)
                .NotEmpty().WithMessage("Debe Ingresar la Tensión Arterial");
            RuleFor(p => p.FrecuenciaRespiratoria)
                .NotEmpty().WithMessage("Debe Ingresar la Frecuencia Respiratoria")
                .InclusiveBetween(10, 25).WithMessage("Debe ingresar un valor entre {From} y {To}");
            RuleFor(p => p.SaturacionOxigeno)
                .NotEmpty().WithMessage("Debe Ingresar la Saturación de Oxigeno")
                .InclusiveBetween(70, 100).WithMessage("Debe ingresar un porcentaje entre {From} y {To}");
            RuleFor(p => p.Temperatura)
                .NotEmpty().WithMessage("Debe Ingresar la Temperatura")
                .InclusiveBetween(25, 42).WithMessage("Debe ingresar un porcentaje entre {From} y {To}");
        }
    }
}
