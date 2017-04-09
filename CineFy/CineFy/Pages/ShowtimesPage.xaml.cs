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
    public partial class ShowtimesPage : ContentPage
    {
        private Cinema Cinema { get; set; }
        private Movie Movie { get; set; }

        private ObservableCollection<Showtime> ShowtimesList;

        private CinemaService Service = new CinemaService();

        public ShowtimesPage(Cinema cinema, Movie movie)
        {
            InitializeComponent();
            Cinema = cinema;
            Movie = movie;

            BindingContext = this;

            OnLoad();
        }

        private async void OnLoad()
        {
            try
            {
                showtimesListView.IsRefreshing = true;
                var showtimes = await Service.GetShowtimes(Cinema.Id, Movie.Id);
                var data = showtimes.ToArray();

                Array.Sort(data, new ShowtimeComparer());

                ShowtimesList = new ObservableCollection<Showtime>(data);
                
                showtimesListView.ItemsSource = ShowtimesList;

            }
            catch (Exception E)
            {
                await DisplayAlert("Error", $"{E} - {E.Message}", "Exit");
                AppControls.CloseApp();
            }
            finally
            {
                showtimesListView.IsRefreshing = false;
            }
        }

        private void ShowtimeListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            showtimesListView.SelectedItem = null;
        }

        protected override bool OnBackButtonPressed()
        {
            Navigation.PopAsync();
            return true;
        }
    }
}

