using Firebase.Auth;
using SSA.Mobil.Database;
using SSA.Mobil.Model;
using SSA.Mobil.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using Firebase;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SSA.Mobil.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class addEvent : ContentPage
    {
        DBHelperEvents dbhelp = new DBHelperEvents();
        public addEvent(string email)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            eventDate.SetValue(DatePicker.MinimumDateProperty, DateTime.Now);
            UserLocalEmail.Text = email;
        }

        private async void addEventDoneTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new eventPage(UserLocalEmail.Text));
        }

        private async void eventRequestButton_Clicked(object sender, EventArgs e)
        {
            var date = eventDate.Date.ToString("dd/MM/yyyy");

            await dbhelp.AddEvent(entryEventIdea.Text,date);
            await DisplayAlert("Alert", "Your idea request sended.","OK");
        }
    }
}