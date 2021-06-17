using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using UberEats.ViewModels;

[assembly: ExportFont("UberMoveMedium.otf", Alias = "uberMedium")]
[assembly: ExportFont("UberMoveBold.otf", Alias = "uberBold")]

namespace UberEats.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InicioSesionView : ContentPage
    {
        public InicioSesionView()
        {
            InitializeComponent();
            BindingContext = new InicioSesionViewModel();
        }
        
    }
}