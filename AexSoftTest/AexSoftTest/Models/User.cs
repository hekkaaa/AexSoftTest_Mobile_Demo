using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AexSoftTest.Models
{
    public class User : INotifyPropertyChanged
    {
        private int _id;
        private string _login;
        private string _password;

        public int Id { get { return _id; } set { _id = value; OnPropertyChanged("Id"); } }
        public string Login { get { return _login; } set { _login = value; OnPropertyChanged("Login"); } }
        public string Password { get { return _password; } set { _password = value; OnPropertyChanged("Password"); } }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
