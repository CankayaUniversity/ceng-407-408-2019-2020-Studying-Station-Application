using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SSA.Mobil.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class addEvent : ContentPage
    {
       
        public addEvent()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            
        }

        private async void addEventDoneTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new eventPage());
        }

        private void eventRequestButton_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}