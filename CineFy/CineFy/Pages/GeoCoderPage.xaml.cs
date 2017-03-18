using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CineFy.Services;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CineFy.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GeoCoderPage : ContentPage
    {

        private Position _position = null;

        public GeoCoderPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            
            try
            {
                _position = await GeoLocation.GetCurrentLocation();
            }
            catch (Exception E)
            {
                _position = null;
            }

            if (_position != null)
                textControl.Text = $"Lat: {_position?.Latitude}, Lng: {_position?.Longitude}.";
            else
                textControl.Text = "Error";
        }

    }
}
