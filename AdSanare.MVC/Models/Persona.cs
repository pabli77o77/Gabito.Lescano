using System;
using System.ComponentModel.DataAnnotations;

namespace AdSanare.MVC.Models
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documento { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
    }
}
