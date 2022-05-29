using AexSoftTest.ViewModels;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AexSoftTest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookPage : ContentPage
    {
        private BookPageViewModel _bookPageViewModel;

        public BookPage()
        {
            InitializeComponent();
            _bookPageViewModel = new BookPageViewModel() { Navigation = this.Navigation };
            BindingContext = _bookPageViewModel;
        }

        void Event_RecoveryDisplayInViewAllCollection(object sender, TextChangedEventArgs e)
        {
            if(string.IsNullOrEmpty(e.NewTextValue))
            {
                _bookPageViewModel.UpdateCollectionView();
            }
        }

        public async void OnTest(object sender, EventArgs e)
        {
            string searchOption = await DisplayActionSheet("Искать по:", "Отмена", null, "Названию", "Автору", "Жанру");
            _bookPageViewModel.SearchBy = searchOption;
        }
    }
}