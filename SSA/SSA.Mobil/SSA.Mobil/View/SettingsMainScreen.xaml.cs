using SSA.Mobil.Database;
using SSA.Mobil.Model;
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
        userData user1;
        DBHelper DBhelper = new DBHelper();
        public SettingsMainScreen(string email)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            UserLocalEmail.Text = email;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            
            user1 = await DBhelper.GetUser(UserLocalEmail.Text);
            NameData.Text = user1.Name;
            SurnameData.Text = user1.Surname;
            departmentData.Text = user1.Department;
            schoolData.Text = user1.schoolName;
        }

        private async void DoneTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new userPage(UserLocalEmail.Text));
        }

        private async void ChangeSurname_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new settingsChangeSurname(UserLocalEmail.Text));
        }

        private async void ChangeName_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new settingsChangeName(UserLocalEmail.Text));
        }

        private async void ChangeSchool_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new settingsChangeSchoolName(UserLocalEmail.Text));
        }
        private async void ChangeEmail_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new settingsChangeEmail(UserLocalEmail.Text));
        }
        private async void ChangeDepartment_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new settingsChangeDepartment(UserLocalEmail.Text));
        }

        private async void ChangeLocation_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new settingsLocationPage());
        }

        private async void ChangePassword_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new settingsChangePassword(UserLocalEmail.Text));
        }
    }
}