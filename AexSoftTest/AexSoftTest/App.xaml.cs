using Xamarin.Forms;

namespace AexSoftTest
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new CollectionBookView();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
