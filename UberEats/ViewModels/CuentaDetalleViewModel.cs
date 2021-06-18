using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace UberEats.ViewModels
{
    public class CuentaDetalleViewModel : BaseViewModel
    {
        //====COMANDOS AQUÍ====
        Command _GuardarCommand;
        public Command GuardarCommand => _GuardarCommand ?? (_GuardarCommand = new Command(GuardarAction));


        //=====================

        //-----VARIABLES Y CONSTANTES-----

        string _Nombre;
        public string Nombre
        {
            get => _Nombre;
            set => SetProperty(ref _Nombre, value);
        }

        string _Direccion;
        public string Direccion
        {
            get => _Direccion;
            set => SetProperty(ref _Direccion, value);
        }

        string _Foto;
        public string Foto
        {
            get => _Foto;
            set => SetProperty(ref _Foto, value);
        }

        double _Longitud;
        public double Longitud
        {
            get => _Longitud;
            set => SetProperty(ref _Longitud, value);
        }

        double _Latitud;
        public double Latitud
        {
            get => _Latitud;
            set => SetProperty(ref _Latitud, value);
        }

        int _IdRestaurante;
        public int IdRestaurante
        {
            get => _IdRestaurante;
            set => SetProperty(ref _IdRestaurante, value);
        }

        
        //--------------------------------

        //____FUNCIONES AQUÍ_____

        public CuentaDetalleViewModel ()
        {
            IdRestaurante = UberEats.App.RestauranteLoged.IdRestaurante;
            Nombre = UberEats.App.RestauranteLoged.Nombre;
            Direccion = UberEats.App.RestauranteLoged.Direccion;
            Latitud = UberEats.App.RestauranteLoged.Latitud;
            Longitud = UberEats.App.RestauranteLoged.Longitud;
            Foto = UberEats.App.RestauranteLoged.Foto;
        }

        private void GuardarAction(object obj)
        {
            Application.Current.MainPage.Navigation.PopAsync();
        }
        //_______________________
    }
}
