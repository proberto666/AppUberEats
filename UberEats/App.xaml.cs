using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using UberEats.Models;

namespace UberEats
{
    public partial class App : Application
    {
        public static RestauranteModel UsuarioLoged;
        public App()
        {
            InitializeComponent();
            UsuarioLoged = new RestauranteModel
            {
                IdRestaurante = 0,
                Nombre = "La embajada",
                Direccion = "Av. Universidad #283",
                Foto = "http://lorempixel.com/120/120",
                Latitud = 21.150012857849237,
                Longitud = -101.70929987271914
            };
            MainPage = new NavigationPage(new Views.InicioSesionView());
           
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
