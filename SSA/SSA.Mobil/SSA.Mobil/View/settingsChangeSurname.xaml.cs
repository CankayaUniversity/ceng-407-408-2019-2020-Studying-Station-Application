﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SSA.Mobil.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class settingsChangeSurname : ContentPage
    {
        public settingsChangeSurname()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        private async void backIcon_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsMainScreen());
        }
        private async void settingsLabel_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsMainScreen());
        }
        private void ChangeSurname_Clicked(object sender, EventArgs e)
        {

        }
    }
}