using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CineFy.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BannerPage : ContentPage
    {
        public BannerPage()
        {
            InitializeComponent();
        }

        private void GetStarted_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CinemasPage());
        }

        private void AboutButton_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AboutPage());
        }
    }
}
