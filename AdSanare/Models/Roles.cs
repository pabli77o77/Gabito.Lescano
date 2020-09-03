using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdSanare.Models
{
    public class Roles
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        // Trasa
        public int IdUsuarioModificacion { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
