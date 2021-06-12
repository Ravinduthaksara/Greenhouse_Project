using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Greenhouse_Project.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Greenhouse_Project
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
           
        }

        public async Task Animate()
        {
            imglogo.Opacity = 50;
            await imglogo.FadeTo(1, 4000);
            Application.Current.MainPage = new Homepage();
        }
    }
}
