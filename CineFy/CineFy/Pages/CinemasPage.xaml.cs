using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CineFy.Entities;
using CineFy.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CineFy.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CinemasPage : ContentPage
    {

        private CinemaService Service = new CinemaService();

        private ObservableCollection<Cinema> CinemaList;
        public CinemasPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                var position = await GeoLocation.GetCurrentLocation();
                var cinemas = await Service.GetCinemas(position.Latitude, position.Longitude, 10);
                CinemaList = new ObservableCollection<Cinema>(cinemas);
                cinemasListView.ItemsSource = CinemaList;
            }
            catch (Exception E)
            {
                await DisplayAlert("Error", E.Message, "Exit");
                AppControls.CloseApp();
            }
            
        }
    }
}
