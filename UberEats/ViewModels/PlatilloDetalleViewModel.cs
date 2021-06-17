using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace UberEats.ViewModels
{
    public class PlatilloDetalleViewModel : BaseViewModel
    {
        //====COMANDOS AQUÍ====
        Command _GuardarCommand;
        public Command GuardarCommand => _GuardarCommand ?? (_GuardarCommand = new Command(GuardarAction));

        
        Command _EliminarCommand;
        public Command EliminarCommand => _EliminarCommand ?? (_EliminarCommand = new Command(EliminarAction));

       
        //=====================

        //-----VARIABLES Y CONSTANTES-----
        //--------------------------------

        //____FUNCIONES AQUÍ_____
        private void GuardarAction(object obj)
        {
            Application.Current.MainPage.Navigation.PopAsync();
        }

        private void EliminarAction(object obj)
        {
            Application.Current.MainPage.Navigation.PopAsync();
        }

    }
}
