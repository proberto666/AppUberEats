using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Text;
using UberEats.Models;
using UberEats.Services;
using Xamarin.Forms;

namespace UberEats.ViewModels
{
    public class DetallePlatilloViewModel : BaseViewModel
    {
        //====COMANDOS AQUÍ====

        Command _GuardarCommand;
        public Command GuardarCommand => _GuardarCommand ?? (_GuardarCommand = new Command(GuardarAction));
        
        Command _EliminarCommand;
        public Command EliminarCommand => _EliminarCommand ?? (_EliminarCommand = new Command(EliminarAction));

        Command _CancelarCommand;
        public Command CancelarCommand => _CancelarCommand ?? (_CancelarCommand = new Command(CancelarAction));

        Command _TomarFotografiaCommand;
        public Command TomarFotografiaCommand => _TomarFotografiaCommand ?? (_TomarFotografiaCommand = new Command(TomarFotografiaActionAsync));

        Command _SeleccionarFotografiaCommand;
        public Command SeleccionarFotografiaCommand => _SeleccionarFotografiaCommand ?? (_SeleccionarFotografiaCommand = new Command(SeleccionarFotografiaAction));

        //=====================

        //-----VARIABLES Y CONSTANTES-----

        ListaPlatillosViewModel ListaPlatillos;

        string _Nombre;
        public string Nombre
        {
            get => _Nombre;
            set => SetProperty(ref _Nombre, value);
        }

        double _Precio;
        public double Precio
        {
            get => _Precio;
            set => SetProperty(ref _Precio, value);
        }

        string _Foto;
        public string Foto
        {
            get => _Foto;
            set => SetProperty(ref _Foto, value);
        }

        //--------------------------------

        //---------FUNCIONES AQUÍ---------

        public DetallePlatilloViewModel(ListaPlatillosViewModel lista)
        {
            ListaPlatillos = lista;
        }

        private async void GuardarAction(object obj)
        {
            ApiResponse response;
            try
            {
                if(_Foto == null)
                {
                    _Foto = "";
                }

                PlatilloModel platillo = new PlatilloModel
                {
                    Nombre = _Nombre,
                    Precio = _Precio,
                    Foto = _Foto,
                    IdRestaurante = UberEats.App.RestauranteLoged.IdRestaurante
                };

                response = await new ApiService().PostDataAsync("platillo", platillo);
                if (response == null || !response.IsSucces)
                {
                    await Application.Current.MainPage.DisplayAlert("Uber Eats", $"Error al procesar la orden {response.Message}", "Ok");
                    return;
                }

                ListaPlatillos.recargarPlatillos();
                await Application.Current.MainPage.Navigation.PopAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void EliminarAction(object obj)
        {
            Application.Current.MainPage.Navigation.PopAsync();
        }

        private async void CancelarAction()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
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

                //GasSelected.Foto = imgBase64 = await new ImageService().ConvertImageFilePathToBase64(file.Path);

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

                //GasFoto = imgBase64 = await new ImageService().ConvertImageFilePathToBase64(file.Path);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("AppTasks", $"Se generó un error ({ex.Message})", "OK");
            }
        }

        //--------------------------------
    }
}
