using System;
using System.Collections.Generic;
using System.Text;
using UberEats.Views;
using UberEats.Models;
using Xamarin.Forms;

namespace UberEats.ViewModels
{
    public class ListaPlatillosViewModel : BaseViewModel
    {
        //====COMANDOS AQUÍ====
        Command _VerOrdenesCommand;
        public Command VerOrdenesCommand => _VerOrdenesCommand ?? (_VerOrdenesCommand = new Command(VerOrdenesAction));

        Command _EditarCuentaCommand;
        public Command EditarCuentaCommand => _EditarCuentaCommand ?? (_EditarCuentaCommand = new Command(EditarCuentaAction));
        
        Command _CerrarSesionCommand;
        public Command CerrarSesionCommand => _CerrarSesionCommand ?? (_CerrarSesionCommand = new Command(CerrarSesionAction));
       
        Command _AgregarCommand;
        public Command AgregarCommand => _AgregarCommand ?? (_AgregarCommand = new Command(AgregarnAction));

        Command _EditarCommand;
        public Command EditarCommand => _EditarCommand ?? (_EditarCommand = new Command(EditarnAction));

       

        //=====================

        //-----VARIABLES Y CONSTANTES-----
        //--------------------------------

        //____FUNCIONES AQUÍ_____
        public ListaPlatillosViewModel()
        {
           
        }
        private void VerOrdenesAction(object obj)
        {
            Application.Current.MainPage.Navigation.PushAsync(new ListaOrdenesView());
        }

        private void EditarCuentaAction(object obj)
        {
            Application.Current.MainPage.Navigation.PushAsync(new CuentaDetalleView());
        }

        private void CerrarSesionAction(object obj)
        {
            Application.Current.MainPage.Navigation.PopAsync();
        }

        private void AgregarnAction(object obj)
        {
            Application.Current.MainPage.Navigation.PushAsync(new PlatilloDetalleView());
        }

        private void EditarnAction(object obj)
        {
            Application.Current.MainPage.Navigation.PushAsync(new PlatilloDetalleView());

        }
        //_______________________

    }
}
