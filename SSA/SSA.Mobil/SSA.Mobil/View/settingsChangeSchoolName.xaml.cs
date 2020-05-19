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
    public partial class settingsChangeSchoolName : ContentPage
    {
        DBHelper DBhelper = new DBHelper();
        userData user1;
        public settingsChangeSchoolName(string email)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            UserLocalEmail.Text = email;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            user1 = await DBhelper.GetUser(UserLocalEmail.Text);
            SchoolDataChangePage.Text = user1.schoolName;
        }
        private async void backIcon_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsMainScreen(UserLocalEmail.Text));
        }
        private async void settingsLabel_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsMainScreen(UserLocalEmail.Text));
        }
        private async void ChangeSchool_Clicked(object sender, EventArgs e)
        {
            await DBhelper.UpdatePersonData(user1.Email, user1.Name, entrySchoolUpdate.Text, user1.Department, user1.Surname, user1.password,user1.imageUrl);
        }
    }
}