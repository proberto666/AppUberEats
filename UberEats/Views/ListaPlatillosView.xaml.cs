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
        private static ListaPlatillosView instance;

        public ListaPlatillosView()
        {
            instance = this;
            InitializeComponent();
            BindingContext = new ListaPlatillosViewModel();

            recargarMapa();

        }

        public static ListaPlatillosView GetInstance()
        {
            return instance;
        }

        public void recargarMapa()
        {
            RestauranteModel RestauranteSeleccionado = UberEats.App.RestauranteLoged;

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

            if (mapaRestaurante.Pins.Count == 1)
            {
                mapaRestaurante.Pins.Clear();
            }

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