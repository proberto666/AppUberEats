using UberEats.Renders;
using UberEats.UWP.Renders;
using System;
using System.Linq;
using Windows.Devices.Geolocation;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls.Maps;
using UberEats.Models;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.UWP;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(MiMapa), typeof(MiMapaRenderer))]
namespace UberEats.UWP.Renders
{
    public class MiMapaRenderer : MapRenderer
    {
        /*MapControl mapaNativo;
        RestauranteModel Restaurante;
        VentanaMapa RestauranteVentana;
        bool VentanaVisible;
       /* protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                mapaNativo.MapElementClick -= OnMapElementClick;
                mapaNativo.Children.Clear();
                mapaNativo = null;
                mapaNativo = null;

            }

            if (e.NewElement != null)
            {
                this.Restaurante = (e.NewElement as MiMapa).restaurante;
                var formsMap = (MiMapa)e.NewElement;
                mapaNativo = Control as MapControl;
                mapaNativo.Children.Clear();
                mapaNativo.MapElementClick += OnMapElementClick;

                var position = new BasicGeoposition
                {
                    Latitude = Restaurante.Latitud,
                    Longitude = Restaurante.Longitud
                };
                var point = new Geopoint(position);
                var mapIcon = new MapIcon();
                mapIcon.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///pin.png"));
                mapIcon.CollisionBehaviorDesired = MapElementCollisionBehavior.RemainVisible;
                mapIcon.Location = point;
                mapIcon.NormalizedAnchorPoint = new Windows.Foundation.Point(0.5, 1.0);

                mapaNativo.MapElements.Add(mapIcon);
            }
        }

        private void OnMapElementClick(MapControl sender, MapElementClickEventArgs args)
        {
            var mapIcon = args.MapElements.FirstOrDefault(x => x is MapIcon) as MapIcon;
            if (!VentanaVisible)
            {
                if (RestauranteVentana == null) RestauranteVentana = new VentanaMapa(Restaurante);
                var position = new BasicGeoposition
                {
                    Latitude = Restaurante.Latitud,
                    Longitude = Restaurante.Longitud
                };
                var point = new Geopoint(position);
                mapaNativo.Children.Add(RestauranteVentana);
                MapControl.SetLocation(RestauranteVentana, point);
                MapControl.SetNormalizedAnchorPoint(RestauranteVentana, new Windows.Foundation.Point(0.5, 1.0));
                VentanaVisible = true;
            }
            else
            {
                mapaNativo.Children.Remove(RestauranteVentana);
                VentanaVisible = false;
            }
        }*/


    }
}
