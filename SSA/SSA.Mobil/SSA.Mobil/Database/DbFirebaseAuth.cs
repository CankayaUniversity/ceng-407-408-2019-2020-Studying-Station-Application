using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSA.Mobil.Database
{
    public class DbFirebaseAuth
    {
        public FirebaseClient client;
        public FirebaseAuth userAuth;
        public FirebaseAuthProvider firebaseAuthProvider;
  
        const string CONFIG_KEY = "AIzaSyBmwHavpfxZUSmh5XrzPGG5YZyddYi3Lpw";
        public DbFirebaseAuth() 
        {
            client = new FirebaseClient("https://ssaplication.firebaseio.com/");
            userAuth = new FirebaseAuth();
            firebaseAuthProvider = new FirebaseAuthProvider(new FirebaseConfig(CONFIG_KEY));
        }
    }
}
