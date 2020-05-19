using Firebase.Auth;
using Newtonsoft.Json;
using SSA.Mobil.Database;
using SSA.Mobil.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media;
using System.IO;

namespace SSA.Mobil.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class userPage : ContentPage
    {
        DbFirebaseAuth service = new DbFirebaseAuth();
        DBHelper DBhelper = new DBHelper();
        DBHelperStorage fire = new DBHelperStorage();
        Stream imgStr;
        userData user1;
        public userPage(string email)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            UserLocalEmail.Text = email;
        }
        
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            user1 = await DBhelper.GetUser(UserLocalEmail.Text);
            //userPhoto.Source = ImageSource.FromUri(new Uri ("https://firebasestorage.googleapis.com/v0/b/ssaplication.appspot.com/o/Images%2FProfileImages%2Fbaris%40mail.com?alt=media&token=b6ad880f-5ec9-4afe-a2df-a6edf3b0ab72"));
            if(user1.imageUrl == null)
            {
                userPhoto.Source = null;
            }
            else
            {
                userPhoto.Source = ImageSource.FromUri(new Uri(user1.imageUrl));
            }
            userFullName.Text = user1.Name + " " + user1.Surname;
        }

        private async void settingsTapped(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new SettingsMainScreen(UserLocalEmail.Text));
        }

        private async void Calendar_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new eventPage(UserLocalEmail.Text));
        }

        private async void feedbackPage_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new feedbackPage(UserLocalEmail.Text));
        }

        async void AddMedia_Tapped(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if(CrossMedia.IsSupported == false)
            {
                await DisplayAlert("Alert","Not supported !", "OK");
            }
            else
            {
                var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions() 
                {
                    
                });

                if(file != null)
                {
                    imgStr = file.GetStream();
                    await fire.saveImage(imgStr, user1);
                    user1 = await DBhelper.GetUser(UserLocalEmail.Text);
                    userPhoto.Source = ImageSource.FromUri(new Uri(user1.imageUrl));
                }
            }
        }

        private async void ChatPageIcon_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new chatRoom(UserLocalEmail.Text));
        }

        private async void DeleteUser_Tapped(object sender, EventArgs e)
        {
            var del = await DisplayAlert("Alert","Are you sure for delete user !","OK","CANCEL");
            if (del == true)
            {
                await service.firebaseAuthProvider.DeleteUserAsync(UserLocalData.userToken);
                await DBhelper.DeleteUser(UserLocalEmail.Text);
                await Navigation.PushAsync(new LoginPage());
            }
            else
            {
                return;
            }
            
        }
    }
}
