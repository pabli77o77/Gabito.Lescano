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
                .Length(3, 100).WithMessage("Debe ingresar entre {MinLength} y {MaxLength} caracteres.");
            RuleFor(p => p.FrecuenciaCardiaca)
                .NotEmpty().WithMessage("Debe Ingresar la Frecuencia Cardiaca");
            RuleFor(p => p.TensionArterial)
                .NotEmpty().WithMessage("Debe Ingresar la Tensión Arterial");
            RuleFor(p => p.FrecuenciaRespiratoria)
                .NotEmpty().WithMessage("Debe Ingresar la Frecuencia Respiratoria");
            RuleFor(p => p.SaturacionOxigeno)
                .NotEmpty().WithMessage("Debe Ingresar la Saturación de Oxigeno");
            RuleFor(p => p.Temperatura)
                .NotEmpty().WithMessage("Debe Ingresar la Temperatura");
        }
    }
}
