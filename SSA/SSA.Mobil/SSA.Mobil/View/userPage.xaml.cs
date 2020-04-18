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
    public partial class userPage : ContentPage
    {
        public userPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void settingsTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsMainScreen());
        }

        private async void Calendar_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new eventPage());
        }

        private async void editInfo_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new editInfo());
        }
    }
}