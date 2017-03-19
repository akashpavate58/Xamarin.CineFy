using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CineFy.Contracts;
using Xamarin.Forms;

namespace CineFy.Services
{
    public class AppControls
    {
        public static void CloseApp()
        {
            if (Device.OS == TargetPlatform.Android)
                DependencyService.Get<IAndroidMethods>().CloseApplication();
        }
    }
}
