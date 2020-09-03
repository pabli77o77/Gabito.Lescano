using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdSanare.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string IdRole { get; set; }
        public bool Activo { get; set; }

        // Trasa
        public int IdUsuarioModificacion { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
