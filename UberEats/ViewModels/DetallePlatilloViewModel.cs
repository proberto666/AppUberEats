using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Text;
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

        Command cancelarCommand;
        public Command CancelarCommand => cancelarCommand ?? (cancelarCommand = new Command(CancelarAction));

        Command tomarFotografiaCommand;
        public Command TakePictureCommand => tomarFotografiaCommand ?? (tomarFotografiaCommand = new Command(TomarFotografiaActionAsync));

        Command seleccionarFotografiaCommand;
        public Command SelectPictureCommand => seleccionarFotografiaCommand ?? (seleccionarFotografiaCommand = new Command(SeleccionarFotografiaAction));

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
    }
}
