using AdSanare.Repository.Interfaces;
using System;

namespace AdSanare.UOW.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IPersonaRepository Personas { get; }
        int Complete();
    }
}
