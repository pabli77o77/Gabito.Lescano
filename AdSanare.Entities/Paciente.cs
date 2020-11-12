using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AdSanare.Entities
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [DisplayName("N° de Documento")]
        public string Documento { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
        [DisplayName("Sexo")]
        public string Sexo { get; set; }
        [DisplayName("Estado Civil")]
        public string EstadoCivil { get; set; }
        public virtual Domicilio Domicilio { get; set; }
        [DisplayName("Telefono")]
        public string Telefono { get; set; }
        public virtual ObraSocial ObraSocial { get; set; }
        [DisplayName("Número de Obra Social")]
        public string ObraSocialNumero { get; set; }
        public bool BajaLogica { get; set; }
        public DateTime FechaBaja { get; set; }
    }
}
