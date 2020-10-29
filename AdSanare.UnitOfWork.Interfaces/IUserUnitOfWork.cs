using AdSanare.Repository.Interfaces;
using System;

namespace AdSanare.UOW.Interfaces
{
    public interface IUserUnitOfWork:IDisposable
    {
        IUsuarioRepository Usuarios { get; }
        IAuditoriaRepository Auditorias { get; }
        int Complete();
    }
}
