using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UberEats.Models;
using UberEats.Services;
using UberEats.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace UberEats.ViewModels
{
    public class CuentaDetalleViewModel : BaseViewModel
    {
        //====INICIALIZACIÓN====

        public CuentaDetalleViewModel(ListaPlatillosViewModel lista)
        {
            ListaPlatillos = lista;

            IdRestaurante = UberEats.App.RestauranteLoged.IdRestaurante;
            Nombre = UberEats.App.RestauranteLoged.Nombre;
            Direccion = UberEats.App.RestauranteLoged.Direccion;
            Latitud = UberEats.App.RestauranteLoged.Latitud;
            Longitud = UberEats.App.RestauranteLoged.Longitud;
            Foto = UberEats.App.RestauranteLoged.Foto;
        }

        //=====================

        //====COMANDOS AQUÍ====
        Command _GuardarCommand;
        public Command GuardarCommand => _GuardarCommand ?? (_GuardarCommand = new Command(GuardarActionAsync));

        Command _ObtenerCoordCommand;
        public Command ObtenerCoordCommand => _ObtenerCoordCommand ?? (_ObtenerCoordCommand = new Command(CoordActionAsync));

        Command _TomarFotografiaCommand;
        public Command TomarFotografiaCommand => _TomarFotografiaCommand ?? (_TomarFotografiaCommand = new Command(TomarFotografiaActionAsync));

        Command _SeleccionarFotografiaCommand;
        public Command SeleccionarFotografiaCommand => _SeleccionarFotografiaCommand ?? (_SeleccionarFotografiaCommand = new Command(SeleccionarFotografiaAction));

        Command _ActualizarCoordCommand;
        public Command ActualizarCoordCommand => _ActualizarCoordCommand ?? (_ActualizarCoordCommand = new Command(ActualizarCoordAction));

        //=====================

        //-----VARIABLES Y CONSTANTES----- 

        ListaPlatillosViewModel ListaPlatillos;

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

        string imgBase64;
        public string ImageBase64
        {
            get => imgBase64;
            set => SetProperty(ref imgBase64, value);
        }

        //--------------------------------

        //____FUNCIONES AQUÍ_____

        private async void GuardarActionAsync(object obj)
        {
            ApiResponse response;
            try
            {
                RestauranteModel aux = new RestauranteModel
                {
                    IdRestaurante = UberEats.App.RestauranteLoged.IdRestaurante,
                    Nombre = _Nombre,
                    Direccion = _Direccion,
                    Latitud = _Latitud,
                    Longitud = _Longitud,
                    Foto = _Foto
                };
                if (aux.Direccion == null || aux.Nombre == null || aux.Foto == null)
                {
                    await Application.Current.MainPage.DisplayAlert("Uber Eats", "No se aceptan campos vacios, por favor llena todos los campos", "OK");
                    return;
                }

                response = await new ApiService().PutDataAsync("restaurante", aux);
                if (response == null || !response.IsSucces)
                {
                    await Application.Current.MainPage.DisplayAlert("Uber Eats", $"Error al procesar los cambios {response.Message}", "OK");
                    return;
                }
                UberEats.App.RestauranteLoged = aux;

                ListaPlatillosView.GetInstance().recargarMapa();

                ListaPlatillos.cargarRestaurante();

                await Application.Current.MainPage.Navigation.PopAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async void TomarFotografiaActionAsync()
        {
            try
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await App.Current.MainPage.DisplayAlert("No Cámara", "Cámara no disponible.", "Ok");
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "PlatillosFotos",
                    Name = "PlatillosPicture.jpg"
                });

                if (file == null)
                    return;

                Foto = imgBase64 = await new ImageService().ConvertImageFilePathToBase64(file.Path);

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("AppTasks", $"Se generó un error ({ex.Message})", "OK");
            }
        }

        private async void SeleccionarFotografiaAction()
        {
            try
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    await App.Current.MainPage.DisplayAlert("UberEats", "No podemos acceder a tu galeria.", "Ok");
                    return;
                }

                var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
                });

                if (file == null)
                    return;

                Foto = imgBase64 = await new ImageService().ConvertImageFilePathToBase64(file.Path);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("AppTasks", $"Se generó un error ({ex.Message})", "OK");
            }
        }

        private async void CoordActionAsync(object obj)
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    Latitud = location.Latitude;
                    Longitud = location.Longitude;
                }
                UberEats.App.RestauranteLoged.Latitud = _Latitud;
                UberEats.App.RestauranteLoged.Longitud = _Longitud;
                CuentaDetalleView.GetInstance().recargarMapa();
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
                await App.Current.MainPage.DisplayAlert("Uber Eats", $"El GPS no esta soportado en el dispositivo({fnsEx.Message})", "Ok");
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
                await App.Current.MainPage.DisplayAlert("Uber Eats", $"GPS no activado({fneEx.Message})", "Ok");
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
                await App.Current.MainPage.DisplayAlert("Uber Eats", $"No se pudo obtener el permiso para las coordenadas del dispositivo({pEx.Message})", "Ok");
            }
            catch (Exception ex)
            {
                // Unable to get location
                await App.Current.MainPage.DisplayAlert("Uber Eats", $"Se generó un error al obtener las coordenadas del dispositivo({ex.Message})", "Ok");
            }
        }

        private async void ActualizarCoordAction(object obj)
        {
            try
            {
                Latitud = _Latitud;
                Longitud = _Longitud;
                UberEats.App.RestauranteLoged.Latitud = _Latitud;
                UberEats.App.RestauranteLoged.Longitud = _Longitud;
                CuentaDetalleView.GetInstance().recargarMapa();
            }
            catch (Exception ex)
            {
                // Unable to get location
                await App.Current.MainPage.DisplayAlert("Uber Eats", $"Se generó un error al octualizar las coordenadas ({ex.Message})", "Ok");
            }
        }

        //_______________________
    }
}
