using SSA.Mobil.Database;
using SSA.Mobil.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSA.Mobil.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SSA.Mobil.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        DbFirebaseAuth service = new DbFirebaseAuth();
        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        
        private async void TappedSignUpLabel(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new signUp());
        }

        private async void SignInButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                var user = await service.firebaseAuthProvider.SignInWithEmailAndPasswordAsync(entryEmail.Text, entryPass.Text);
                UserLocalData.userToken = user.FirebaseToken;   
                await Navigation.PushAsync(new userPage(entryEmail.Text),true);
            }
            catch(Exception ex)
            {
                Console.WriteLine("err {0}", ex.Message);
                await DisplayAlert("Alert", "Incorrect password or email. Please try again", "OK");
            }
        }

        private async void TappedForgotPass(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new forgetPass());
        }
    }
}