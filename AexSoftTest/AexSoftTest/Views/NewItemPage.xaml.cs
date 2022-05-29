using AexSoftTest.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AexSoftTest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {
        public NewItemPage(BookPageViewModel obj)
        {
            InitializeComponent();
            BindingContext = new NewItemPageViewModel(obj);
        }
    }
}