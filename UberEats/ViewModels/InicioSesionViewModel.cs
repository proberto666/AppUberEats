using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UberEats.Models;
using UberEats.Services;
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
        string _Usuario;
        public string Usuario
        {
            get => _Usuario;
            set => SetProperty(ref _Usuario, value);
        }

        string _Contrasena;
        public string Contrasena
        {
            get => _Contrasena;
            set => SetProperty(ref _Contrasena, value);
        }

        string _Alerta;
        public string Alerta
        {
            get => _Alerta;
            set => SetProperty(ref _Alerta, value);
        }
        //--------------------------------


        //____FUNCIONES AQUÍ_____
        private async void IniciarSesionAction(object obj)
        {
            UberEats.App.NegocioLoged = new NegocioModel
            {
                usuario = _Usuario,
                contrasena = _Contrasena
            };
            ApiResponse response = new ApiResponse();

            if (Usuario != null  && Contrasena != null )
            {
                response = await new ApiService().GetDataByStringAsync<NegocioModel>("negocio", UberEats.App.NegocioLoged.usuario);
            }
            else
            {
                if (Usuario == null)
                {
                    Alerta = "Campo Usuario incompleto";
                    Contrasena = null;
                }
                if (Contrasena == null)
                {
                    Alerta = "Campo contrasena incompleto";
                    Usuario = null;
                }
                if(Usuario == null && Contrasena == null)
                {
                    Alerta = "Por favor ingrese sus datos";
                }
                
            }

            if (!response.IsSucces || response == null)
            {
                Alerta = "Error en usuario o contrasena";
            }
            else
            {
                NegocioModel aux = (NegocioModel)response.Response;
                if(aux.contrasena == UberEats.App.NegocioLoged.contrasena)
                {
                    UberEats.App.NegocioLoged = aux;

                    ApiResponse restaurante = await new ApiService().GetDataByIntAsync<RestauranteModel>("restaurante", UberEats.App.NegocioLoged.idRestaurante);

                    UberEats.App.RestauranteLoged = (RestauranteModel)restaurante.Response;

                    await Application.Current.MainPage.Navigation.PushAsync(new ListaPlatillosView());
                }
                else
                {
                    Alerta = "Error en usuario o contrasena";
                }
            }
        }

        public InicioSesionViewModel() {
        }
        //________________________

    }
}
