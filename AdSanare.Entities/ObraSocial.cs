using System;
using System.ComponentModel;
namespace AdSanare.Entities
{
    public class ObraSocial
    {
        public int Id { get; set; }
        [DisplayName("Nombre de la Obra Social")]
        public string Descripcion { get; set; }
        public bool BajaLogica { get; set; }
        public DateTime FechaBaja { get; set; } = DateTime.Now;
    }
}