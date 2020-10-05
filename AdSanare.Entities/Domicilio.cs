﻿using System.ComponentModel;

namespace AdSanare.Entities
{
    public class Domicilio
    {
        public int Id { get; set; }
        [DisplayName("Calle")]
        public string Calle { get; set; }
        [DisplayName("Localidad")]
        public string Localidad { get; set; }
        [DisplayName("Provincia")]
        public string Provincia { get; set; }
    }
}