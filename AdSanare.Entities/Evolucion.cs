using System;
using System.ComponentModel.DataAnnotations;

namespace AdSanare.Entities
{
    public class Evolucion
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaEvolucion { get; set; }
        public virtual Ingreso Ingreso { get; set; }
        public virtual Servicio ServicioInternacion { get; set; }
        public virtual Cama CamaInternacion { get; set; }
        public virtual ExamenFisico ExamenFisico { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}