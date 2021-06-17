using System;
using System.Collections.Generic;
using System.Text;

namespace UberEats.Models
{
    public class RestauranteModel
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Imagen { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
    }
}
