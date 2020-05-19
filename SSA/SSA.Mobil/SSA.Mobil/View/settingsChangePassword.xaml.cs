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
    public partial class settingsChangePassword : ContentPage
    {
        DbFirebaseAuth db = new DbFirebaseAuth();
        DBHelper DBhelper = new DBHelper();
        userData user1;
        public settingsChangePassword(string email)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            UserLocalEmail.Text = email;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            user1 = await DBhelper.GetUser(UserLocalEmail.Text);
        }
        private async void backIcon_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsMainScreen(UserLocalEmail.Text));
        }

        private async void settingsLabel_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsMainScreen(UserLocalEmail.Text));
        }

        private async void ChangePass_Clicked(object sender, EventArgs e)
        {
            if(entryPassUpdate1.Text == entryPassUpdate2.Text)
            {
                await DBhelper.UpdatePersonData(user1.Email, user1.Name, user1.schoolName, user1.Department, user1.Surname, entryPassUpdate2.Text, user1.imageUrl);
                await db.firebaseAuthProvider.ChangeUserPassword(UserLocalData.userToken,entryPassUpdate2.Text);
            }
            else
            {
                await DisplayAlert("Alert","Please enter same password ","OK");
            }
            
        }
    }
}