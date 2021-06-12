using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Greenhouse_Project.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Controller_page : ContentPage
    {
        public Controller_page()
        {
            InitializeComponent();
        }
        private async void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            bool isToggled = e.Value;

            if(e.Value == true)
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Auto Mode Is On", "OK");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Auto Mode Is Off", "OK");
            }
        }

        private void light_on_Clicked(object sender, EventArgs e)
        {
            
        }

        private void light_off_Clicked(object sender, EventArgs e)
        {

        }

        private void fan_on_Clicked(object sender, EventArgs e)
        {

        }

        private void fan_off_Clicked(object sender, EventArgs e)
        {

        }

        private void pump_on_Clicked(object sender, EventArgs e)
        {

        }

        private void pump_off_Clicked(object sender, EventArgs e)
        {

        }
    }
}