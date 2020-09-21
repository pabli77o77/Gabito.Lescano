using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AdSanare.Entities
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [DisplayName("Número de Documento")]
        public string Documento { get; set; }
        [DisplayName("Obra Social")]
        public string ObraSocial { get; set; }
        [DisplayName("Número de Obra Social")]
        public string ObraSocialNumero { get; set; }
        [DisplayName("Diagnóstico")]
        public string Diagnostico { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
    }
}
