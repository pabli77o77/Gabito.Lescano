using System;
using System.ComponentModel;

namespace AdSanare.Entities
{
    public class ExamenFisico
    {
        public int Id { get; set; }
        [DisplayName("Estado Actual")]
        public string EstadoActual { get; set; }
        [DisplayName("Frecuencia Cardiaca")]
        public int FrecuenciaCardiaca { get; set; }
        [DisplayName("Tension Arterial")]
        public string TensionArterial { get; set; }
        [DisplayName("Frecuencia Respiratoria")]
        public int FrecuenciaRespiratoria { get; set; }
        [DisplayName("Saturación de Oxigeno")]
        public int SaturacionOxigeno { get; set; }
        [DisplayName("Temperatura")]
        public decimal Temperatura { get; set; }
        public bool BajaLogica { get; set; }
        public DateTime FechaBaja { get; set; }
    }
}