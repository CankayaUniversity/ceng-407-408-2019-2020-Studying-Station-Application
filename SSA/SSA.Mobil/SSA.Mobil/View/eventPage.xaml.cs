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
        public eventPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            var list = new List<eventDeneme>
            {
                new eventDeneme{Name="Datadan gelen Eventler", imageSource="starIcon.png"},
                new eventDeneme{ Name="Yine tekrar varsa datadan gelenler sıralanır", imageSource="starIcon.png"}
            };

            lstViewEvent.ItemsSource = list;
        }

        private async void backEvent_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new userPage());
        }

        private async void backLabel_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new userPage());
        }

        private async void addEvent_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new addEvent());
        }
    }
}