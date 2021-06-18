using System.Collections.Generic;
using UberEats.Views;
using UberEats.Models;
using Xamarin.Forms;
using UberEats.Services;

namespace UberEats.ViewModels
{
    public class ListaPlatillosViewModel : BaseViewModel
    {
        //====COMANDOS AQUÍ====
        Command _AgregarCommand; //Agregar platillo en PlatilloDetalleView
        public Command AgregarCommand => _AgregarCommand ?? (_AgregarCommand = new Command(AgregarAction));

        Command _EditarCommand; //Editar platillo en PlatilloDetalleView
        public Command EditarCommand => _EditarCommand ?? (_EditarCommand = new Command(EditarAction));

        Command _VerOrdenesCommand; //Abrir ListaOrdenesView
        public Command VerOrdenesCommand => _VerOrdenesCommand ?? (_VerOrdenesCommand = new Command(VerOrdenesAction));

        Command _EditarCuentaCommand; //Abrir CuentaDetalleView
        public Command EditarCuentaCommand => _EditarCuentaCommand ?? (_EditarCuentaCommand = new Command(EditarCuentaAction));

        Command _CerrarSesionCommand;
        public Command CerrarSesionCommand => _CerrarSesionCommand ?? (_CerrarSesionCommand = new Command(CerrarSesionAction));

        //=====================

        //-----VARIABLES Y CONSTANTES-----

        PlatilloModel _PlatilloSelected;
        public PlatilloModel PlatilloSelected
        {
            get => _PlatilloSelected;
            set
            {
                if (SetProperty(ref _PlatilloSelected, value))
                {
                    EditarAction(PlatilloSelected);
                }
            }
        }

        List<PlatilloModel> _ListaPlatillos;
        public List<PlatilloModel> ListaPlatillos
        {
            get => _ListaPlatillos;
            set => SetProperty(ref _ListaPlatillos, value);
        }

        string _FotoRestaurante;
        public string FotoRestaurante
        {
            get => _FotoRestaurante;
            set => SetProperty(ref _FotoRestaurante, value);
        }

        string _NombreRestaurante;
        public string NombreRestaurante
        {
            get => _NombreRestaurante;
            set => SetProperty(ref _NombreRestaurante, value);
        }

        string _Direccion;
        public string Direccion
        {
            get => _Direccion;
            set => SetProperty(ref _Direccion, value);
        }

        //--------------------------------

        //---------FUNCIONES AQUÍ---------

        public ListaPlatillosViewModel()
        {
            cargarPlatillos();
            Direccion = UberEats.App.RestauranteLoged.Direccion;
            NombreRestaurante = UberEats.App.RestauranteLoged.Nombre;
            FotoRestaurante = UberEats.App.RestauranteLoged.Foto;
        }

        private async void cargarPlatillos()
        {
            ApiResponse platillos = await new ApiService().GetDataListByIntAsync<PlatilloModel>("platillo", UberEats.App.NegocioLoged.idRestaurante);
            if (platillos == null || !platillos.IsSucces)
            {
                await Application.Current.MainPage.DisplayAlert("Uber Eats", $"Error al cargar las ordenes {platillos.Message}", "OK");
                return;
            }

            ListaPlatillos = (List<PlatilloModel>)platillos.Response;
        }

        public void recargarPlatillos()
        {
            cargarPlatillos();
        }

        private void AgregarAction(object obj)
        {
            Application.Current.MainPage.Navigation.PushAsync(new DetallePlatilloView(this));
        }

        private void EditarAction(object obj)
        {
            Application.Current.MainPage.Navigation.PushAsync(new DetallePlatilloView(this, PlatilloSelected));
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
      
        //_______________________

    }
}
