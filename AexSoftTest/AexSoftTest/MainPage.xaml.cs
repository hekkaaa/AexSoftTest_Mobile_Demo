using AexSoftTest.ViewModels;
using AexSoftTest.Views;
using Xamarin.Forms;

namespace AexSoftTest
{
    public partial class MainPage : Shell
    {
        public MainPage()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(BookPage), typeof(BookPage));
        }
    }
}
