using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SSA.Mobil.View
{
    public class splashScreen : ContentPage
    {
        Image splashImage;
        public splashScreen()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            var sub = new AbsoluteLayout();
            splashImage = new Image
            {
                Source = "splashLogo.jpg",
                WidthRequest = 100,
                HeightRequest = 100       
            };
            AbsoluteLayout.SetLayoutFlags(splashImage, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(splashImage, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            sub.Children.Add(splashImage);

            this.BackgroundColor = Color.FromHex("#FFFFFF");
            this.Content = sub;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await splashImage.ScaleTo(1, 5000);
            
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }
    }
}
