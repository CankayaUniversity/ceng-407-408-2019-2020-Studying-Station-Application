﻿using SSA.Mobil.Database;
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
    public partial class settingsChangeName : ContentPage
    {
        DBHelper DBhelper = new DBHelper();
        userData user1;
        public settingsChangeName(string email)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            UserLocalEmail.Text = email;
            
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            user1 = await DBhelper.GetUser(UserLocalEmail.Text);
            NameDataChangePage.Text = user1.Name;
        }

        private async void backIcon_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsMainScreen(UserLocalEmail.Text));
        }

        private async void ChangeName_Clicked(object sender, EventArgs e)
        {
            await DBhelper.UpdatePersonData(user1.Email, entryNameUpdate.Text,user1.schoolName,user1.Department,user1.Surname,user1.password,user1.imageUrl);

        }

        private async void settingsLabel_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsMainScreen(UserLocalEmail.Text));
        }
    }
}