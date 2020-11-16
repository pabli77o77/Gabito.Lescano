using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AdSanare.Entities
{
    [Serializable]
    public class Evolucion
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Fecha de Evolución")]
        public DateTime FechaEvolucion { get; set; }
        public virtual Ingreso Ingreso { get; set; }
        [DisplayName("Servicio")]
        public virtual Servicio ServicioInternacion { get; set; }
        [DisplayName("Cama")]
        public virtual Cama CamaInternacion { get; set; }
        public virtual ExamenFisico ExamenFisico { get; set; }
        public bool BajaLogica { get; set; }
        public DateTime FechaBaja { get; set; }
    }
}