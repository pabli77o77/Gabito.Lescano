using System;
using System.ComponentModel;

namespace AdSanare.Entities
{
    [Serializable]
    public class Domicilio
    {
        public int Id { get; set; }
        [DisplayName("Calle")]
        public string Calle { get; set; }
        [DisplayName("Localidad")]
        public string Localidad { get; set; }
        [DisplayName("Provincia")]
        public string Provincia { get; set; }
        public bool BajaLogica { get; set; }
        public DateTime FechaBaja { get; set; }
    }
}