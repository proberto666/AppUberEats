using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberEats.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UberEats.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaOrdenesView : ContentPage
    {
        public ListaOrdenesView()
        {
            InitializeComponent();
            BindingContext = new ListaOrdenesViewModel();
        }
    }
}