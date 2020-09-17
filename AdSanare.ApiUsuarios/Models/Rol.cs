using System;

namespace AdSanare.ApiUsuarios.Models
{
    public partial class Rol
    {
        public short Id { get; set; }
        public string RoleDesc { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public int IdUsuarioUltimaModificacion { get; set; }
    }
}
