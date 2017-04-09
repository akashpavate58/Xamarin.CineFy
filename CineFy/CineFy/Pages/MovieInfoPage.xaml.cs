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
                return Movie.Ratings["imdb"].Value.ToString();
            }
        }
        public MovieInfoPage(Movie movie)
        {
            InitializeComponent();
            Movie = movie;
            castListView.ItemsSource = new ObservableCollection<Person>(Movie.Cast);
            BindingContext = this;
        }
    }
}
