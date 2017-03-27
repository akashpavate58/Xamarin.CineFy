using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CineFy.Entities;
using CineFy.Services;
using Plugin.Geolocator.Abstractions;
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
            BindingContext = this;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                var position = await GeoLocation.GetCurrentLocation();
                var cinemas = await Service.GetCinemas(position.Latitude, position.Longitude, 20);
                CinemaList = new ObservableCollection<Cinema>(cinemas);
                cinemasListView.ItemsSource = CinemaList;

            }
            catch (GeolocationException E)
            {
                await DisplayAlert("Error", "Please enable the location service.", "Exit");
                AppControls.CloseApp();
            }
            catch (Exception E)
            {
                await DisplayAlert("Error", $"{E} - {E.Message}", "Exit");
                AppControls.CloseApp();
            }
            
        }

        private void CinemasListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            cinemasListView.SelectedItem = null;
        }

        //private void CallButton_OnTapped(object sender, EventArgs e)
        //{
            
        //    Device.OpenUri(new Uri("tel:+13133988222"));
        //}

        public ICommand OnCallButtonTapped
        {
            get
            {
                return new Command<Cinema>(cinema =>
                    {
                        Device.OpenUri(new Uri($"tel:{cinema.Telephone}"));
                    }
                );
            }
        }
    }
}
