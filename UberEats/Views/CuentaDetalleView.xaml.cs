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
        private static CuentaDetalleView instance;
        public CuentaDetalleView(ListaPlatillosViewModel lista)
        {
            instance = this;
            InitializeComponent();
            BindingContext = new CuentaDetalleViewModel(lista);
            recargarMapa();
        }

        public static CuentaDetalleView GetInstance()
        {
            return instance;
        }

        public void recargarMapa()
        {
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