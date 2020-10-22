using System.ComponentModel;

namespace AdSanare.Entities
{
    public class Servicio
    {
        public int Id { get; set; }
        [DisplayName("Nombre del Servicio")]
        public string Descripcion { get; set; }
    }
}