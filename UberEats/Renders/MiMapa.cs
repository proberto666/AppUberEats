using System;
using System.Collections.Generic;
using System.Text;
using UberEats.Models;
using Xamarin.Forms.Maps;

namespace UberEats.Renders
{
    public class MiMapa : Map
    {
        public RestauranteModel restaurante { get; set; }
    }
}
