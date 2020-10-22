using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AdSanare.Entities
{
    public class Ingreso
    {
        public int Id { get; set; }
        public virtual Paciente Paciente { get; set; }
        [DisplayName("Fecha de Ingreso")]
        [DataType(DataType.Date)]
        public DateTime FechaIngreso { get; set; }
        [DisplayName("Fecha de Egreso")]
        [DataType(DataType.Date)]
        public DateTime? FechaEgreso { get; set; }
        [DisplayName("Defunción")]
        public bool Defuncion { get; set; }
        [DisplayName("Diagnostico")]
        public string Diagnostico { get; set; }
        [DisplayName("Antecedentes Medicos")]
        public string AntecedentesMedicos { get; set; }
        [DisplayName("Antecedentes Quirurgicos")]
        public string AntecedentesQuirurgicos { get; set; }
        [DisplayName("Alergias")]
        public string Alergias { get; set; }
        [DisplayName("Medicación Habitual")]
        public string MedicacionHabitual { get; set; }
        [DisplayName("Peso")]
        public decimal Peso { get; set; }
        [DisplayName("Talla")]
        public decimal Talla { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
