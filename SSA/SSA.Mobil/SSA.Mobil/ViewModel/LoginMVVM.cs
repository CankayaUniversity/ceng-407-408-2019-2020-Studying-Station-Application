using Firebase.Auth;
using SSA.Mobil.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SSA.Mobil.ViewModel
{
    public class LoginMVVM : INotifyPropertyChanged
    {
        Page page;
        DbFirebaseAuth service;
        string _email;
        string _password;
        
        public LoginMVVM(Page page)
        {
            this.page = page;
            service = new DbFirebaseAuth();
        }

       
        public string userEmail 
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public string userPassword 
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged ([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
