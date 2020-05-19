using SSA.Mobil.Database;
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
    public partial class feedbackPage : ContentPage
    {
        DBHelperFeedback db = new DBHelperFeedback();
        public feedbackPage(string email)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            UserLocalEmail.Text = email;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var list = await db.GetAllFeedbacks();
            lstViewFeedback.ItemsSource = list;
           /*
            Label lbl = (Label)lstViewFeedback.FindByName("scoreLabel");
            int score = Int32.Parse(lbl.Text);    */ 
        }

        private async void backFeedbackPage_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new userPage(UserLocalEmail.Text));
        }

        private async void backLabel_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new userPage(UserLocalEmail.Text));
        }

        private async void addFeedback_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new addFeedback(UserLocalEmail.Text));
        }
    }
}