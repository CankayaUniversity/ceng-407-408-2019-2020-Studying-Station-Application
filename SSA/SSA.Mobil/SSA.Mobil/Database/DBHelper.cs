using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using SSA.Mobil.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSA.Mobil.Database
{
    public class DBHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://ssaplication.firebaseio.com/");
        public async Task<List<userData>> GetAllUsers()
        {

            return (await firebase
              .Child("UserSSA")
              .OnceAsync<userData>()).Select(item => new userData
              {
                  Email = item.Object.Email,
                  password = item.Object.password,
                  Surname = item.Object.Surname,
                  schoolName = item.Object.schoolName,
                  Department = item.Object.Department,
                  Name = item.Object.Name,
                  imageUrl = item.Object.imageUrl
              }).ToList();
        }

        public async Task AddUser(string email, string name, string surname, string department, string pass, string schoolName)
        {
             await firebase
                    .Child("UserSSA")
                    .PostAsync(new userData() { Email = email, Name = name, Surname = surname, Department = department, password = pass, schoolName = schoolName});
            
        }

        public async Task<userData> GetUser(string email)
        {
            var allUsers = await GetAllUsers();
            await firebase
              .Child("UserSSA")
              .OnceAsync<userData>();
            return allUsers.Where(a => a.Email == email).FirstOrDefault();
        }

        public async Task UpdatePersonData(string email, string name,string school,string department,string surname,string pass, string url)
        {
            var toUpdateUser = (await firebase
              .Child("UserSSA")
              .OnceAsync<userData>()).Where(a => a.Object.Email == email).FirstOrDefault();

            await firebase
              .Child("UserSSA")
              .Child(toUpdateUser.Key)
              .PutAsync(new userData() { Email=email, Name = name, schoolName=school,Department=department, Surname = surname, password=pass ,imageUrl = url});
        }
    }
}
