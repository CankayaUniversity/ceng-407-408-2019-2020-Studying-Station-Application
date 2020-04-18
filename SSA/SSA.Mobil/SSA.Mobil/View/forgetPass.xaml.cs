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
    public partial class forgetPass : ContentPage
    {
        public forgetPass()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void varyCodeButton_Clicked(object sender, EventArgs e)
        {
            varyCodeEntery.IsVisible = true ;
            changePassButton.IsVisible = true ;
        }

        private async void changePassButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChangePass());
        }
    }
}