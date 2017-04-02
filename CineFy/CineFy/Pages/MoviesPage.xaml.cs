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
    public partial class MoviesPage : ContentPage
    {
        private Cinema Cinema { get; set; }

        private ObservableCollection<Movie> MovieList;

        private CinemaService Service = new CinemaService();

        public MoviesPage(Cinema cinema)
        {
            InitializeComponent();
            Cinema = cinema;
            BindingContext = this;

            OnLoad();
        }

        private async void OnLoad()
        {
            try
            {
                var movies = await Service.GetMoviesByCinemaId(Cinema.Id);
                MovieList = new ObservableCollection<Movie>(movies.Where(m => m.Title != null));
                moviesListView.ItemsSource = MovieList;
                var c = MovieList[0].PosterImageThumbnail;
            }
            catch (Exception E)
            {
                await DisplayAlert("Error", $"{E} - {E.Message}", "Exit");
                AppControls.CloseApp();
            }
        }

        private void CinemasListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            moviesListView.SelectedItem = null;
        }
        
    }
}
