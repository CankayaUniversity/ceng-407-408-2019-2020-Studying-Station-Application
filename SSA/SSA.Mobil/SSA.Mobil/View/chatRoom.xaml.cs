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
    public partial class chatRoom : ContentPage
    {
        DBChat db = new DBChat();
        public chatRoom(string email)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            userEmail.Text = email;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var list = await db.getRoomListAsync();
            lstViewChatRoom.BindingContext = list;
        }
        private async void backChat_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new userPage(userEmail.Text));
        }
        private async void backLabel_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new userPage(userEmail.Text));
        }
        private async void addRoom_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new addRoomPage());
        }

        private async void lstViewChatRoom_Refreshing(object sender, EventArgs e)
        {
            lstViewChatRoom.BindingContext = await db.getRoomListAsync();
            lstViewChatRoom.IsRefreshing = false;
        }

        private void selectRoom_ItemTapped(object sender, SelectedItemChangedEventArgs e)
        {
            if(lstViewChatRoom.SelectedItem != null)
            {
                var selectRoom = (chatRoomModel)lstViewChatRoom.SelectedItem;
                Navigation.PushAsync(new chatPage(userEmail.Text));
                MessagingCenter.Send<chatRoom, chatRoomModel>(this, "roomProp", selectRoom);
                
            }
        }

   
    }
}