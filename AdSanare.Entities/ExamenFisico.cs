namespace AdSanare.Entities
{
    public class ExamenFisico
    {
        public int Id { get; set; }
        public virtual Evolucion Evolucion { get; set; }
        public string EstadoActual { get; set; }
        public int FrecuenciaCardiaca { get; set; }
        public string TensionArterial { get; set; }
        public int FrecuenciaRespiratoria { get; set; }
        public int SaturacionOxigeno { get; set; }
        public decimal Temperatura { get; set; }
    }
}