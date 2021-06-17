using System;
using System.Collections.Generic;
using System.Text;

namespace UberEats.Models
{
    public class RestauranteModel
    {
        public int IdRestaurante { get; set; }

        public string Nombre { get; set; }

        public string Foto { get; set; }

        public string Direccion { get; set; }

        public double Longitud { get; set; }

        public double Latitud { get; set; }

    }
}
