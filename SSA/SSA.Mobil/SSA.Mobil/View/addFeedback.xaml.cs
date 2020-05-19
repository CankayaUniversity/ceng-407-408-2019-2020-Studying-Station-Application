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
    public partial class addFeedback : ContentPage
    {
        DBHelperFeedback db = new DBHelperFeedback();
        public addFeedback( string email)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            UserLocalEmail.Text = email;
        }

        private async void addFeedbackDoneTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new feedbackPage(UserLocalEmail.Text));
        }

        private async void feedbackRequestButton_Clicked(object sender, EventArgs e)
        {
            string scoreText = ScoreFeedback.Text;
            int score = Int32.Parse(scoreText);
            if(score<0 || score > 5)
            {
                await DisplayAlert("Alert", "Enter score 0-5", "OK");
                ScoreFeedback.Text = null;
            }
            else
            {
                await db.AddFeedback(entryFeedbackIdea.Text, score);
                await DisplayAlert("Alert", "Your idea request sended.", "OK");
            }
            
        }

        private void ScoreFeedback_Focused(object sender, FocusEventArgs e)
        {
            ((Entry)sender).Text = string.Empty;
        }
    }
}