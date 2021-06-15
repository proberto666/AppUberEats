using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiUberEats.Models
{
    public class PlatilloModel
    {
        public int IdPlatillo { get; set; }

        public string Nombre { get; set; }

        public float Precio { get; set; }

        public string Foto { get; set; }

        public bool Vegano { get; set; }
    }
}
