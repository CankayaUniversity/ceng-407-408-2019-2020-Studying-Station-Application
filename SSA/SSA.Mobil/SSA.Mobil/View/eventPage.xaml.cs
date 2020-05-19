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
    public partial class eventPage : ContentPage
    {
        DBHelperEvents dbhelper = new DBHelperEvents();
        public eventPage(string email)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            UserLocalEmail.Text = email;
            
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var list = await dbhelper.GetAllEvents();
            lstViewEvent.ItemsSource = list;
        }
        private async void backEvent_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new userPage(UserLocalEmail.Text));
        }

        private async void backLabel_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new userPage(UserLocalEmail.Text));
        }

        private async void addEvent_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new addEvent(UserLocalEmail.Text));
        }
    }
}