using System;

namespace AdSanare.Entities
{
    public class Auditoria
    {
        public int Id { get; set; }
        public int EntidadId { get; set; }
        public string Entidad { get; set; }
        public string TipoEntidad { get; set; }
        public virtual Usuario Usuario { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
    }
}
