using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CineFy.Entities;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CineFy.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieInfoPage : ContentPage
    {
        public Movie Movie { get; set; }

        public string IMDBRating {
            get
            {
                try
                {
                    var rating = Movie.Ratings["imdb"]?.Value.ToString();
                    return rating;
                }
                catch (Exception E)
                {
                    return "Not Available";
                }
            }
        }
        public MovieInfoPage(Movie movie)
        {
            InitializeComponent();
            Movie = movie;
            castListView.ItemsSource = new ObservableCollection<Person>(Movie.Cast);
            BindingContext = this;
        }

        private void CastListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            castListView.SelectedItem = null;
        }
    }
}
