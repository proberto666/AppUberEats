using System;
using System.Collections.Generic;
using System.Text;

namespace UberEats.Models
{
    public class PlatilloModel
    {
        public int IdPlatillo { get; set; }

        public string Nombre { get; set; }

        public double Precio { get; set; }

        public string Foto { get; set; }

        public int IdRestaurante { get; set; }

        public string NombreRestaurante { get; set; }
    }
}
