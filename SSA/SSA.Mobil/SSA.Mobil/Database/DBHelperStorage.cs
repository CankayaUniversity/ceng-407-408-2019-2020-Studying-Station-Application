using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using Firebase.Storage;
using SSA.Mobil.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SSA.Mobil.Database
{
    public class DBHelperStorage
    {
        FirebaseClient client = new FirebaseClient("https://ssaplication.firebaseio.com/"); 
        FirebaseStorage storage = new FirebaseStorage("ssaplication.appspot.com");
        DBHelper dbhelp = new DBHelper();
        userData user1 = new userData();
        public async Task saveImage(Stream str, userData user)
        {
            
            user1 = await dbhelp.GetUser(user.Email);
            var name = user1.Email;
            var data =  storage.Child("Images")
                .Child("ProfileImages")
                .Child(name.ToString());
           
            string imageUrl = await data.PutAsync(str,new System.Threading.CancellationToken(), "image/jpeg");
            await dbhelp.UpdatePersonData(user1.Email, user1.Name, user1.schoolName, user1.Department, user1.Surname, user1.password, imageUrl);
        }
    }
}
