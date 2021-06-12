using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Greenhouse_Project.Models;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Firebase.Auth;
using User = Greenhouse_Project.Models.User;

namespace Greenhouse_Project.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Signuppage : ContentPage
    {
        private string WebAPIkey = "Your API key";
        public Signuppage()
        {
            InitializeComponent();
        }

        public Signuppage(string username, string password, string confirmpassword, string Email)
        {
            this.signup_u_entry.Text = username;
            this.signup_p_entry.Text = password;
            this.signup_c_entry.Text = confirmpassword;
            this.useremail.Text = Email;
        }

        private async void Signup_button_Clicked(object sender, EventArgs e)
        {
            User user = new User();
            user.username = signup_u_entry.Text;
            user.password = signup_p_entry.Text;
            user.confirmpassword = signup_c_entry.Text;
            user.Email = useremail.Text;

            if (useremail.Text == null || signup_u_entry.Text == null || signup_p_entry.Text == null || signup_c_entry.Text == null)
            {
                await DisplayAlert("Alert", "Please complete details ", "OK");
            }
            else
            {

                try
                {
                    var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
                    var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(useremail.Text, signup_c_entry.Text);
                    string getToken = auth.FirebaseToken;
                    await App.Current.MainPage.DisplayAlert("Sign in Notification", "Account Created Succesfully", "Ok");
                }
                catch(Exception)
                {
                    await App.Current.MainPage.DisplayAlert("Sign in Notification", "Account Not Created Try again", "Ok");
                }
            }
        }

        private void backtohome_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Loginpage());
        }
    }
}