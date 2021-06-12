using Firebase.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Greenhouse_Project.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Loginpage : ContentPage
    {
        private string WebAPIkey = "AIzaSyBFr3I-LUw9GFRjYoyPW8KhT7Y080eJ3F8";
        public Loginpage()
        {
            InitializeComponent();
        }

        public Loginpage(string email,string password)
        {

        }
        private async void loginbutton_Clicked(object sender, EventArgs e)
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
            try
            {
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(uemail.Text, upassword.Text);
                var content = await auth.GetFreshAuthAsync();
                var serializedcontent = JsonConvert.SerializeObject(content);
                Preferences.Set("MyFirebaseRefreshToken", serializedcontent);
                await Navigation.PushAsync(new Dashboard());

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                await App.Current.MainPage.DisplayAlert("Login message", "Invalid Useremail or Password", "OK");
            }
        }
    }
}