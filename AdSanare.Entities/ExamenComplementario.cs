using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AdSanare.Entities
{
    [Serializable]
    public class ExamenComplementario
    {
        public int Id { get; set; }
        public virtual Paciente Paciente { get; set; }
        [DisplayName("Fecha de Examen")]
        [DataType(DataType.Date)]
        public DateTime FechaExamen { get; set; }
        [DisplayName("Tipo de Examen")]
        public string TipoExamen { get; set; }
        [DisplayName("Detalle")]
        public string Detalle { get; set; }
        public bool BajaLogica { get; set; }
        public DateTime FechaBaja { get; set; }
    }
}
