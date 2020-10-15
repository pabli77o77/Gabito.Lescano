using AdSanare.Repository.Interfaces;
using System;

namespace AdSanare.UOW.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IPacienteRepository Pacientes { get; }
        IExamenComplementarioRepository ExamenesComplementarios { get; }
        int Complete();
    }
}
