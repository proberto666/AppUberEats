using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiUberEats.Models
{
    public class RestauranteModel
    {
        public int IdRestaurante { get; set; }

        public string Nombre { get; set; }

        public string Foto { get; set; }

        public string Direccion { get; set; }

        public float Longitud { get; set; }

        public float Latitud { get; set; }

        public MenuModel Menu { get; set; }
    }
}
