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
        //--------------------------------

        //____FUNCIONES AQUÍ_____

        public CuentaDetalleViewModel (){}

        private void GuardarAction(object obj)
        {
            Application.Current.MainPage.Navigation.PopAsync();
        }
        //_______________________
    }
}
