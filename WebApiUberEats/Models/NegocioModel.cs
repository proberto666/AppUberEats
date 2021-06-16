using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiUberEats.Models
{
    public class NegocioModel
    {
        public int NumNegocio { get; set; }

        public string Usuario { get; set; }

        public string Contrasena { get; set; }

        public RestauranteModel IdRestaurante { get; set; }


    }
}
