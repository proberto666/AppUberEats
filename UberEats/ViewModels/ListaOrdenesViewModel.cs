﻿using System;
using System.Collections.Generic;
using System.Text;
using UberEats.Views;
using Xamarin.Forms;

namespace UberEats.ViewModels
{
    public class ListaOrdenesViewModel : BaseViewModel
    {
        //====COMANDOS AQUÍ====
        Command _AgregarCommand;
        public Command AgregarCommand => _AgregarCommand ?? (_AgregarCommand = new Command(AgregarAction));

        
        //=====================

        //-----VARIABLES Y CONSTANTES-----
        //--------------------------------

        //____FUNCIONES AQUÍ_____
        public ListaOrdenesViewModel() { }
        private void AgregarAction(object obj)
        {
            Application.Current.MainPage.Navigation.PushAsync(new DetalleOrdenView());
        }
        //_______________________
    }
}