using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CineFy.Contracts;
using CineFy.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidMethods))]
namespace CineFy.Droid
{
    public class AndroidMethods : IAndroidMethods
    {
        public void CloseApplication()
        {
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }
    }
}