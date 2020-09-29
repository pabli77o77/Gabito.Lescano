namespace AdSanare.Entities
{
    public class Cama
    {
        public int Id { get; set; }
        public virtual Servicio ServicioInternacion { get; set; }
        public string Descripcion { get; set; }
    }
}