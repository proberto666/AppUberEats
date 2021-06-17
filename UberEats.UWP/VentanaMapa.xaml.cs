using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using UberEats.Models;
// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace UberEats.UWP
{
    public sealed partial class VentanaMapa : UserControl
    {
        public VentanaMapa(RestauranteModel restaurante)
        {
            this.InitializeComponent();
            NombreVentana.Text = restaurante.Nombre;
            DireccionVentana.Text = restaurante.Direccion;
        }
    }
}
