using AexSoftTest.Models;
using Business.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AexSoftTest.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private readonly UserService _userService;
        private string _textErrorMessage;
        private bool _visibleError = default;

        public User User { get; set; }

        public LoginViewModel()
        {
            User = new User();
            _userService = new UserService();
        }

        public string Login
        {
            get { return User.Login; }
            set
            {
                if (User.Login != value)
                {
                    User.Login = value;
                    OnPropertyChanged("Login");
                }
            }
        }

        public string Password
        {
            get { return User.Password; }
            set
            {
                if (User.Password != value)
                {
                    User.Password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        public string TextErrorMessage
        {
            get
            {
                return _textErrorMessage;
            }
            set
            {
                _textErrorMessage = value;
                OnPropertyChanged("TextErrorMessage");
            }
        }

        public bool VisibleError
        {
            get { return _visibleError; }
            set
            {
                _visibleError = value;
                OnPropertyChanged("VisibleError");
            }
        }

        public ICommand AuthCommand => new Command(() =>
        {
            
            bool resAuth = _userService.AuthUser(User.Login,User.Password);
            if (resAuth)
            {
                Application.Current.MainPage = new MainPage();
            }
            else
            {
                ErrorLogPass();
            }
            
        });


        public ICommand NewUserCommand => new Command(() =>
        {
            if (string.IsNullOrWhiteSpace(User.Login) || string.IsNullOrWhiteSpace(User.Password))
            {
                ErrorEntryIsNullText();
            }
            if (User.Login.IndexOf(' ') > 0 || User.Password.IndexOf(' ') > 0)
            {
                ErrorWhitespacesTextMessage();
            }

            try
            {
                bool resCreate = _userService.AddUser(User.Login, User.Password);
                if (resCreate)
                {
                    Application.Current.MainPage = new MainPage();
                }
                else 
                { 
                    ErrorSQLWorking(); 
                }
            }
            catch (ArgumentException)
            {
                DublicateUser();
            }
            catch(Exception)
            {
                ErrorSQLWorking();
            }
        });


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }


        private void ErrorLogPass()
        {
            ErrorMessage("Неверно введен логин или пароль");
        }
        private void DublicateUser()
        {
            ErrorMessage("Такой пользователь уже есть в системе");
        }

        private void ErrorSQLWorking()
        {
            ErrorMessage("Ошибка при работе SQL. Попробуйте еще раз или перезапустите приложение");
        }

        private void ErrorEntryIsNullText()
        {
            ErrorMessage("Логин и пароль не должны быть пустыми");
        }

        private void ErrorWhitespacesTextMessage()
        {
            ErrorMessage("В логине или пароле содержатся пробелы");
        }

        private void ErrorMessage(string message)
        {
            User.Login = string.Empty;
            User.Password = string.Empty;
            TextErrorMessage = message;
            VisibleError = true;
            Task.Factory.StartNew(() =>
            {
                Task.Delay(6000).Wait();
                VisibleError = false;
            });
        }

       
    }
}
