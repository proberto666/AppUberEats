using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberEats.Models;
using UberEats.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace UberEats.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CuentaDetalleView : ContentPage
    {
        public CuentaDetalleView(ListaPlatillosViewModel lista)
        {
            InitializeComponent();
            BindingContext = new CuentaDetalleViewModel(lista);
            RestauranteModel RestauranteSeleccionado = UberEats.App.RestauranteLoged;
            //mapaRestaurante.restaurante = RestauranteSeleccionado;

            //establecer ubicación
            mapaRestaurante.MoveToRegion(
                MapSpan.FromCenterAndRadius(
                    new Position(
                        RestauranteSeleccionado.Latitud,
                        RestauranteSeleccionado.Longitud
                    ),
                    Distance.FromMiles(.5)
                )
            );

            //agregar pin
            mapaRestaurante.Pins.Add(
                new Pin
                {
                    Type = PinType.Place,
                    Label = RestauranteSeleccionado.Nombre,
                    Position = new Position(
                        RestauranteSeleccionado.Latitud,
                        RestauranteSeleccionado.Longitud
                    )
                }
            );
        }
    }
}