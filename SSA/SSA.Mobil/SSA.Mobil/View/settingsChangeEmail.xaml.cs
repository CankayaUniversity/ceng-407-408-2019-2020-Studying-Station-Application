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
    public partial class settingsChangeEmail : ContentPage
    {
        public settingsChangeEmail(string email)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            UserLocalEmail.Text = email;
        }
        private async void backIcon_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsMainScreen(UserLocalEmail.Text));
        }
        private async void settingsLabel_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsMainScreen(UserLocalEmail.Text));
        }
        private void ChangeEmail_Clicked(object sender, EventArgs e)
        {

        }
    }
}