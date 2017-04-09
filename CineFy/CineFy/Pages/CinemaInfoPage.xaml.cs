using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CineFy.Entities;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CineFy.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CinemaInfoPage : ContentPage
    {
        public Cinema Cinema { get; set; }  

        public CinemaInfoPage(Cinema cinema)
        {
            InitializeComponent();

            Cinema = cinema;
            BindingContext = this;
        }

        private void Navigate_OnTapped(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri($"google.navigation:q={ Cinema.Location }"));
        }

        private void Globe_OnTapped(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri(Cinema.Website));
        }

        protected override bool OnBackButtonPressed()
        {
            Navigation.PopAsync();
            return true;
        }
    }
}
