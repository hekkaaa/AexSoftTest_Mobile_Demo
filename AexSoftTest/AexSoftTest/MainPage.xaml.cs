using AexSoftTest.ViewModels;
using AexSoftTest.Views;
using System;
using Xamarin.Forms;

namespace AexSoftTest
{
    public partial class MainPage : Shell
    {
        public MainPage()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(BookPage), typeof(BookPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        }

        private async void ExitForProfileApplication(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
