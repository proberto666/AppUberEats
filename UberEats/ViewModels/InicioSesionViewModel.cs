using System;
using System.Collections.Generic;
using System.Text;
using UberEats.Views;
using Xamarin.Forms;

namespace UberEats.ViewModels
{
    public class InicioSesionViewModel : BaseViewModel
    {
        //====COMANDOS AQUÍ====
        Command _IniciarSesionCommand;
        public Command IniciarSesionCommand => _IniciarSesionCommand ?? (_IniciarSesionCommand = new Command(IniciarSesionAction));
        //=====================

        //-----VARIABLES Y CONSTANTES-----
        //--------------------------------

        //____FUNCIONES AQUÍ_____
        private void IniciarSesionAction(object obj)
        {
            Application.Current.MainPage.Navigation.PushAsync(new ListaPlatillosView());
        }

        public InicioSesionViewModel() {
        }
        //________________________

    }
}
