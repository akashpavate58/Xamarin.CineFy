using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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
                moviesListView.IsRefreshing = true;
                var movies = await Service.GetMoviesByCinemaId(Cinema.Id);
                MovieList = new ObservableCollection<Movie>(movies.Where(m => m.Title != null));
                moviesListView.ItemsSource = MovieList;

            }
            catch (Exception E)
            {
                await DisplayAlert("Error", $"{E} - {E.Message}", "Exit");
                AppControls.CloseApp();
            }
            finally
            {
                moviesListView.IsRefreshing = false;
            }
        }

        private void CinemasListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            moviesListView.SelectedItem = null;
        }

        private void MoviesListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            Movie movie = (Movie) e.Item;
            Navigation.PushAsync(new ShowtimesPage(Cinema, movie));
        }

        protected override bool OnBackButtonPressed()
        {
            Navigation.PopAsync();
            return true;
        }

        public ICommand OnInfoButtonTapped
        {
            get
            {
                return new Command<Movie>(movie =>
                    {
                        Navigation.PushAsync(new MovieInfoPage(movie));
                    }
                );
            }
        }
    }
}
