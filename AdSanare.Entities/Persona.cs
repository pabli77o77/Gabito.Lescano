using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AdSanare.Entities
{
    public class Persona
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe Ingresar el Nombre")]
        [MinLength(length:3, ErrorMessage ="Debe ingresar tres caracteres mínimo")]
        [MaxLength(length:100, ErrorMessage ="Debe ingresar cien caracteres máximo")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe Ingresar el Apellido")]
        [MinLength(length: 3, ErrorMessage = "Debe ingresar tres caracteres mínimo")]
        [MaxLength(length: 100, ErrorMessage = "Debe ingresar cien caracteres máximo")]
        public string Apellido { get; set; }
        [DisplayName("Número de Documento")]
        [Required(ErrorMessage = "Debe Ingresar el Documento")]
        [MinLength(length: 6, ErrorMessage = "Debe ingresar seis caracteres mínimo")]
        [MaxLength(length: 9, ErrorMessage = "Debe ingresar nueve caracteres máximo")]
        public string Documento { get; set; }
        [DisplayName("Obra Social")]
        [Required(ErrorMessage = "Debe Ingresar el nombre de la Obra Social")]
        [MinLength(length: 3, ErrorMessage = "Debe ingresar seis caracteres mínimo")]
        [MaxLength(length: 100, ErrorMessage = "Debe ingresar cien caracteres máximo")]
        public string ObraSocial { get; set; }
        [DisplayName("Número de Obra Social")]
        [Required(ErrorMessage = "Debe Ingresar el numero de afiliado de la Obra Social")]
        [MinLength(length: 6, ErrorMessage = "Debe ingresar seis caracteres mínimo")]
        [MaxLength(length: 10, ErrorMessage = "Debe ingresar diez caracteres máximo")]
        public string ObraSocialNumero { get; set; }
        [DisplayName("Diagnóstico")]
        [Required(ErrorMessage = "Debe Ingresar el Diagnóstico del Paciente")]
        [MinLength(length: 10, ErrorMessage = "Debe ingresar diez caracteres mínimo")]
        [MaxLength(length: 200, ErrorMessage = "Debe ingresar doscientos caracteres máximo")]
        public string Diagnostico { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
    }
}
