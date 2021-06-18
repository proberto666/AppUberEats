using UberEats.Models;
using UberEats.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UberEats.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetallePlatilloView : ContentPage
    {
        public DetallePlatilloView(ListaPlatillosViewModel lista)
        {
            InitializeComponent();
            BindingContext = new DetallePlatilloViewModel(lista);
        }

        public DetallePlatilloView(ListaPlatillosViewModel lista, PlatilloModel PlatilloSelected)
        {
            InitializeComponent();
            BindingContext = new DetallePlatilloViewModel(lista, PlatilloSelected);
        }
    }
}