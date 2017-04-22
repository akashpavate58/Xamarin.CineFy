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
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
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

            OnLoad();
        }

        private void OnLoad()
        {
            RefreshCinemas();
        }

        private async void RefreshCinemas()
        {
            try
            {
                cinemasListView.IsRefreshing = true;
                var position = await GeoLocation.GetCurrentLocation();
                var cinemas = await Service.GetCinemas(position.Latitude, position.Longitude, (int) Slider.Value);
                CinemaList = new ObservableCollection<Cinema>(cinemas.Where(c => c.Name != null));
                cinemasListView.ItemsSource = CinemaList;

            }
            catch (GeolocationException E)
            {
                await DisplayAlert("Error", "Please enable the location service.", "Exit");
                AppControls.CloseApp();
            }
            catch (TaskCanceledException E)
            {
                await DisplayAlert("Oops..!!", "Unable to find your location. Please try again.", "Ok");
            }
            catch (Exception E)
            {
                await DisplayAlert("Error", $"{E} - {E.Message}", "Exit");
                AppControls.CloseApp();
            }
            finally
            {
                cinemasListView.IsRefreshing = false;
            }
        }

        private void CinemasListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            cinemasListView.SelectedItem = null;
        }
        
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
        public ICommand OnInfoButtonTapped
        {
            get
            {
                return new Command<Cinema>(cinema =>
                    {
                        Navigation.PushAsync(new CinemaInfoPage(cinema));
                    }
                );
            }
        }
        private async void CinemasListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            Cinema c = (Cinema) e.Item;
            await Navigation.PushAsync(new MoviesPage(c));
        }

        private void ApplyFilter_OnClicked(object sender, EventArgs e)
        {
            RefreshCinemas();
        }
    }
}
