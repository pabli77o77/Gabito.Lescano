using System;
using System.ComponentModel.DataAnnotations;

namespace AdSanare.Entities
{
    public class Ingreso
    {
        public int Id { get; set; }
        public virtual Paciente Paciente { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaIngreso { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaEgreso { get; set; }
        public bool Defuncion { get; set; }
        public string Diagnostico { get; set; }
        public string AntecedentesMedicos { get; set; }
        public string AntecedentesQuirurgicos { get; set; }
        public string Alergias { get; set; }
        public string MedicacionHabitual { get; set; }
        public decimal Peso { get; set; }
        public decimal Talla { get; set; }
    }
}
