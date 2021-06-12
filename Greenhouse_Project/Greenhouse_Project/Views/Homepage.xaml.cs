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
    public partial class Homepage : ContentPage
    {
        
        public Homepage()
        {
            InitializeComponent();

            
        }

        private void loginbutton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Loginpage());
        }

        private void signupbutton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Signuppage());
        }
    }
}