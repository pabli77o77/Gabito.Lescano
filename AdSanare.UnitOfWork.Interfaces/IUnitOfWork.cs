using AdSanare.Repository.Interfaces;
using System;

namespace AdSanare.UOW.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IPacienteRepository Pacientes { get; }
        IExamenComplementarioRepository ExamenesComplementarios { get; }
        ICamaRepository Camas { get; }
        IServicioRepository Servicios { get; }
        IIngresoRepository Ingresos { get; }
        IEvolucionRepository Evoluciones { get; }
        IExamenFisicoRepository ExamenesFisicos { get; }
        int Complete();
    }
}
