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
    public partial class addRoomPage : ContentPage
    {
        public addRoomPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var db = new DBChat();
            await db.saveRoom(new chatRoomModel() { roomName = rootName.Text });
            await Navigation.PopAsync();
        }
    }
}