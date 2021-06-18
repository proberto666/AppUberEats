using System;
using System.Collections.Generic;
using System.Text;
using UberEats.Models;
using UberEats.Services;
using UberEats.Views;
using Xamarin.Forms;

namespace UberEats.ViewModels
{
    public class ListaOrdenesViewModel : BaseViewModel
    {
        //====COMANDOS AQUÍ====

        Command _AgregarCommand; //Redirecciona a DetallerOrden
        public Command AgregarCommand => _AgregarCommand ?? (_AgregarCommand = new Command(AgregarAction));

        //=====================

        //-----VARIABLES Y CONSTANTES-----

        List<OrdenModel> _ListaOrdenes;
        public List<OrdenModel> ListaOrdenes
        {
            get => _ListaOrdenes;
            set => SetProperty(ref _ListaOrdenes, value);
        }

        //--------------------------------

        //____FUNCIONES AQUÍ_____
        public ListaOrdenesViewModel() 
        {
            cargarOrdenes();
        }

        private async void cargarOrdenes()
        {
            ApiResponse ordenes = await new ApiService().GetDataListByIntAsync<OrdenModel>("ordenes", UberEats.App.NegocioLoged.idRestaurante);
            if(ordenes == null || !ordenes.IsSucces)
            {
                await Application.Current.MainPage.DisplayAlert("Uber Eats", $"Error al cargar las ordenes {ordenes.Message}", "OK");
                return;
            }

            ListaOrdenes = (List<OrdenModel>)ordenes.Response;
        }

        public void recargarOrdenes()
        {
            cargarOrdenes();
        }

        private void AgregarAction(object obj)
        {
            Application.Current.MainPage.Navigation.PushAsync(new DetalleOrdenView(this));
        }
        //_______________________
    }
}
