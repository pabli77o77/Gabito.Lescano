using AdSanare.Entities;

namespace AdSanare.Repository.Interfaces
{
    public interface IUsuarioRepository:IGenericRepository<Usuario>
    {
        Usuario Get(string Id);
        Usuario GetByUserName(string Name);
    }
}
