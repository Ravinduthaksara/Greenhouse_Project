using System;
using Xamarin.Forms;
using Greenhouse_Project.Views;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace Greenhouse_Project
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            
            MainPage = new NavigationPage(new Homepage());

            if (!string.IsNullOrEmpty(Preferences.Get("UserFirebaseRefreshToken", "")))
            {
                MainPage = new NavigationPage(new Dashboard());
            }
            else
            {
                MainPage = new NavigationPage(new Homepage());
            }
        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
