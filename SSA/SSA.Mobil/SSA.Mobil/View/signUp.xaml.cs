using Firebase.Auth;
using SSA.Mobil.Database;
using SSA.Mobil.Model;
using SSA.Mobil.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using Firebase;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SSA.Mobil.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class signUp : ContentPage
    {
        DbFirebaseAuth service = new DbFirebaseAuth();
        DBHelper db = new DBHelper();
        userData user1 = new userData();
        int count;
        public signUp()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }


        public async Task AddUser(string email, string name, string surname, string department, string pass, string schoolName)
        {
            await service.client
                    .Child("UserSSA")
                    .PostAsync(new userData() { Email = email, Name = name, Surname = surname, Department = department, password = pass, schoolName = schoolName, });
        }

        private async void SignUpButton_Clicked(object sender, EventArgs e)
        {
            if ((string.IsNullOrWhiteSpace(emailSignUp.Text)) || (string.IsNullOrWhiteSpace(nameSignUp.Text)) ||
                (string.IsNullOrWhiteSpace(surnameSignUp.Text)) || (string.IsNullOrWhiteSpace(schoolSignUp.Text)) ||
                (string.IsNullOrWhiteSpace(departmentSignUp.Text)) || (string.IsNullOrWhiteSpace(passwordSignUp.Text)) ||
                (string.IsNullOrEmpty(emailSignUp.Text)) || (string.IsNullOrEmpty(nameSignUp.Text)) ||
                (string.IsNullOrEmpty(surnameSignUp.Text)) || (string.IsNullOrEmpty(schoolSignUp.Text)) ||
                (string.IsNullOrEmpty(departmentSignUp.Text)) || (string.IsNullOrEmpty(passwordSignUp.Text)))
            {
                await DisplayAlert("Enter Data", "Enter Valid Data", "OK");
            }
            else
            {
                user1 = await db.GetUser(emailSignUp.Text);
                if (user1 == null)
                {
                    try
                    {
                        await AddUser(emailSignUp.Text, nameSignUp.Text, surnameSignUp.Text, departmentSignUp.Text, passwordSignUp.Text, schoolSignUp.Text);
                        registerUser(emailSignUp.Text, passwordSignUp.Text);
                        await Navigation.PushAsync(new LoginPage());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("err {0}", ex.Message);
                        await DisplayAlert("Alert", "Email is used try another email.", "OK");
                    }
                }
                else
                {
                    await DisplayAlert("Alert", "Email is used try another email.", "OK");
                }
            }

        }

        async void registerUser(string email, string pass)
        {
            var user = await service.firebaseAuthProvider.CreateUserWithEmailAndPasswordAsync(email, pass);
        }

    }
}