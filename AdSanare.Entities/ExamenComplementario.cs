using System;
using System.ComponentModel.DataAnnotations;

namespace AdSanare.Entities
{
    public class ExamenComplementario
    {
        public int Id { get; set; }
        public virtual Paciente Paciente { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaExamen { get; set; }
        public string TipoExamen { get; set; }
        public string Detalle { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
