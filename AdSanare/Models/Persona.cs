using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdSanare.Models
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoDocumento { get; set; }
        public string Documento { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int IdUsuario { get; set; }

        // Trasa
        public int IdUsuarioModificacion { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
