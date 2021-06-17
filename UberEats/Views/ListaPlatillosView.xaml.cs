using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberEats.ViewModels;
using UberEats.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;

namespace UberEats.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaPlatillosView : ContentPage
    {
        public ListaPlatillosView()
        {
            InitializeComponent();
            BindingContext = new ListaPlatillosViewModel();
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