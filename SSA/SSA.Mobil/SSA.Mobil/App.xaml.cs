﻿using SSA.Mobil.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SSA.Mobil
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
            MainPage = new NavigationPage(new splashScreen());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {

        }
    }
}
