using AexSoftTest.Models;
using AexSoftTest.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AexSoftTest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditItemPage : ContentPage
    {
        public EditItemPage(BookPageViewModel obj, BookModel model)
        {
            InitializeComponent();
            BindingContext = new NewItemPageViewModel(obj, model);
        }
    }
}