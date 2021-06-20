using System;
using System.Collections.Generic;
using System.Text;
using UberEats.Models;
using UberEats.Services;
using UberEats.Views;
using Xamarin.Forms;

namespace UberEats.ViewModels
{
    public class DetalleOrdenViewModel : BaseViewModel
    {
        //====COMANDOS AQUÍ====
        Command _AgregarCommand;
        public Command AgregarCommand => _AgregarCommand ?? (_AgregarCommand = new Command(AgregarAction));

        //=====================

        //-----VARIABLES Y CONSTANTES-----

        ListaOrdenesViewModel ListaOrdenes;

        string _Fecha;
        public string Fecha
        {
            get => _Fecha;
            set => SetProperty(ref _Fecha, value);
        }

        string _Cliente;
        public string Cliente
        {
            get => _Cliente;
            set => SetProperty(ref _Cliente, value);
        }

        double _Total;
        public double Total
        {
            get => _Total;
            set => SetProperty(ref _Total, value);
        }
        //--------------------------------

        //____FUNCIONES AQUÍ_____

        public DetalleOrdenViewModel(ListaOrdenesViewModel lista) 
        {
            ListaOrdenes = lista;
        }

        private async void AgregarAction(object obj)
        {
            ApiResponse response;
            try
            {
                OrdenModel orden = new OrdenModel
                {
                    Fecha = _Fecha,
                    Cliente = _Cliente,
                    Total = _Total,
                    IdRestaurante = UberEats.App.RestauranteLoged.IdRestaurante
                };
                if (orden.Cliente == null || orden.Fecha == null || orden.Total <= 0)
                {
                    await Application.Current.MainPage.DisplayAlert("Uber Eats", "No se aceptan campos vacios, por favor llena todos los campos", "OK");
                    return;
                }

                response = await new ApiService().PostDataAsync("ordenes", orden);
                if (response == null || !response.IsSucces)
                {
                    await Application.Current.MainPage.DisplayAlert("Uber Eats", $"Error al procesar la orden {response.Message}", "OK");
                    return;
                }

                ListaOrdenes.recargarOrdenes();
                await Application.Current.MainPage.Navigation.PopAsync();
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        //_______________________
    }
}
