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
    public partial class chatPage : ContentPage
    {
        DBChat db = new DBChat();
        chatRoomModel rm = new chatRoomModel();
        DBHelper DBhelper = new DBHelper();
        userData user1 = new userData();
        public chatPage(string email)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            userLocalEmail.Text = email;
            MessagingCenter.Subscribe<chatRoom, chatRoomModel>(this, "roomProp", (page, data) =>
            {
                rm = data;
                _lstChat.BindingContext = db.subChat(data.Key);
                MessagingCenter.Unsubscribe<chatRoom, chatRoomModel>(this,"roomProp");
            });
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            user1 = await DBhelper.GetUser(userLocalEmail.Text);
        }

            private async void SendMessage_Clicked(object sender, EventArgs e)
        {
            var chatObj = new chatMessage { userMessage = entryMessage.Text, userName = user1.Name + " " + user1.Surname };
            await db.saveMessage(chatObj,rm.Key);
            entryMessage.Text = null;
        }

        private async void backChatRoom_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new chatRoom(userLocalEmail.Text));
        }

        private async void backLabel_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new chatRoom(userLocalEmail.Text));
        }

        private void entryMessage_Focused(object sender, FocusEventArgs e)
        {
            ((Entry)sender).Text = string.Empty;
        }
    }
}