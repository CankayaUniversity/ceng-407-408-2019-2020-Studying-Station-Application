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
    public partial class SettingsMainScreen : ContentPage
    {
        public SettingsMainScreen()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void DoneTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new userPage());
        }

        private async void ChangeSurname_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new settingsChangeSurname());
        }

        private async void ChangeName_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new settingsChangeName());
        }

        private async void ChangeSchool_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new settingsChangeSchoolName());
        }
        private async void ChangeEmail_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new settingsChangeEmail());
        }
        private async void ChangeDepartment_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new settingsChangeDepartment());
        }

        private async void ChangeLocation_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new settingsLocationPage());
        }
    }
}