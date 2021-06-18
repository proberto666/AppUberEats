using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using UberEats.Models;
using System.Collections.Generic;

namespace UberEats
{
    public partial class App : Application
    {
        public static RestauranteModel RestauranteLoged;
        public static NegocioModel NegocioLoged;
        public static List<PlatilloModel> ListaPlatilos = new List<PlatilloModel>();

        public App()
        {
            InitializeComponent();
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
