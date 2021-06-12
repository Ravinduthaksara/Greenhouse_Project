using Firebase.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greenhouse_Project.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Greenhouse_Project.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : ContentPage
    {
        private string WebAPIkey = "AIzaSyBFr3I-LUw9GFRjYoyPW8KhT7Y080eJ3F8";

        Firebasehelper firebaseHelper = new Firebasehelper();
      
        public Dashboard()
        {
            InitializeComponent();

            GetProfileInformationAndRefreshToken();

            
        }

        private async void GetProfileInformationAndRefreshToken()
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
            try 
            {
                //FirebaseAuthentication
                 var savedFirebaseAuth = JsonConvert.DeserializeObject<Firebase.Auth.FirebaseAuth>(Preferences.Get("UserFirebaseRefreshToken", ""));
                //Refreshing the token
                var RefreshedContent = await authProvider.RefreshAuthAsync(savedFirebaseAuth);
                Preferences.Set("UserFirebaseRefreshToken", JsonConvert.SerializeObject(RefreshedContent));
                //getting user information
                var userdetails = savedFirebaseAuth.User.Email;
            }

            catch(Exception ex )
            {
                Console.WriteLine(ex.Message);
                await App.Current.MainPage.DisplayAlert("Security Alert", "Oh no! Token Expired", "OK");
            }
            
            
        }

        private void controllerbutton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Controller_page());
        }

        private void Logoutbutton_Clicked(object sender, EventArgs e)
        {
            Preferences.Remove("UserFirebaseRefreshToken");
            App.Current.MainPage = new NavigationPage(new Homepage());
            
        }

        private void refreshbutton_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}