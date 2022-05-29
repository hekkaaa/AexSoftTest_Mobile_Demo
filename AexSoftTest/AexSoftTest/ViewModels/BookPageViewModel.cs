using AexSoftTest.Mappers;
using AexSoftTest.Models;
using AexSoftTest.Views;
using Business.Services;
using Data.ConnectDb;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AexSoftTest.ViewModels
{
    public class BookPageViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<BookModel> _bookCollection;
        private readonly BookService _bookService;
        private readonly Mapper _mapper;
        private BookModel _selectedItemBook;
        private bool _searchIsNull = default;
        private bool _visibleErrorSQL = default;
        private bool _nullCollection = default;
        private string _test = "True";
        private string _searchBy = "Названию";
        public INavigation Navigation { get; set; }


        public string SearchBy
        {
            get
            {
                return _searchBy;
            }
            set
            {
                _searchBy = value;
            }
        }

        public ObservableCollection<BookModel> BookCollection
        {
            get { return _bookCollection; }
            set 
            { 
                _bookCollection = value; 
                OnPropertyChanged("BookCollection"); 
            }
        }

        public string IsVisibleSearchPanel
        {
            get
            {
                return _test;
            }
            set
            {
                _test = value;
                OnPropertyChanged("IsVisibleSearchPanel");
            }
        }

        public bool NullCollection
        {
            get
            {
                return _nullCollection;
            }
            set
            {
                _nullCollection = value;
                OnPropertyChanged("NullCollection");
            }
        }

        public bool SearchIsNull
        {
            get { return _searchIsNull; }
            set
            {
                _searchIsNull = value;
                OnPropertyChanged("SearchIsNull");
            }
        }

        public bool VisibleErrorSQL
        {
            get
            {
                return _visibleErrorSQL;
            }

            set
            {
                _visibleErrorSQL = value;
                OnPropertyChanged("VisibleErrorSQL");
            }
        }

        public BookModel SelectedItemBook
        {
            get
            {
                return _selectedItemBook;
            }
            set
            {
                if (_selectedItemBook != value)
                {
                    _selectedItemBook = value;
                    OnPropertyChanged("SelectedItemBook");
                    Navigation.PushAsync(new EditItemPage(this, _selectedItemBook));
                }
            }
        }

        public BookPageViewModel()
        {
            _bookService = new BookService();
            _mapper = new Mapper();
            UpdateCollectionView();
        }

        public ICommand CreateItemCommand => new Command(() =>
        {
            var s = ConnectSettings.PathDatabaseUser;
            var s1 = ConnectSettings.PathDatabaseCollection;
            Navigation.PushAsync(new NewItemPage(this));
        });

        public ICommand DeleteItemCommand => new Command<NewItemPageViewModel>((NewItemPageViewModel obj) =>
        {
            BookModel itemBookModel = obj.BookItem;
            if (itemBookModel != null)
            {
                bool resultDel = _bookService.DeleteBook(itemBookModel.Id);
                if (resultDel)
                {
                    UpdateCollectionView();
                }
                else
                {
                    MessageErrorSQL();
                }
            }

            Back();

        });

        public ICommand BackCommand => new Command(() =>
        {
            Back();
        });

        public ICommand SaveItemCommand => new Command<NewItemPageViewModel>((NewItemPageViewModel obj) =>
        {
            BookModel itemBookModel = obj.BookItem;

            if (itemBookModel != null)
            {
                bool createValue = _bookService.AddBook(_mapper.MapInBookBusinessModel(itemBookModel));
                if (createValue)
                {
                    UpdateCollectionView();
                }
                else
                {
                    MessageErrorSQL();
                }
            }
            Back();
        });

        public ICommand EditItemCommand => new Command<NewItemPageViewModel>((NewItemPageViewModel obj) =>
        {
            BookModel itemBookModel = obj.BookItem;
            bool resultUpdate = _bookService.UpdateBook(_mapper.MapInBookBusinessModel(itemBookModel));
           
            if (resultUpdate)
            {
                UpdateCollectionView();
            }
            else
            {
                MessageErrorSQL();
            }

            Back();
        });

        public ICommand PerformSearchCommand => new Command<string>((string textQuery) =>
        {
            ObservableCollection<BookModel> tmpResult;
            SelectionSettingSearch(out tmpResult, textQuery);

            if (tmpResult.Count > 0)
            {
                BookCollection = tmpResult;
            }
            else
            {
                BookCollection = tmpResult;
                SearchIsNull = true;
                Task.Factory.StartNew(() =>
                {
                    Task.Delay(3500).Wait();
                    UpdateCollectionView();
                });
            }
        });


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private void Back()
        {
            Navigation.PopAsync();
        }

        private void MessageErrorSQL()
        {
            Task.Factory.StartNew(() =>
            {
                VisibleErrorSQL = true;
                Task.Delay(5000).Wait();
                VisibleErrorSQL = false;
            });
        }

        public void UpdateCollectionView()
        {
            _bookCollection = _mapper.MapFromListBookBusinessModel(_bookService.GetBookAll());
            BookCollection = _bookCollection;
            SearchIsNull = false;

            if (_bookCollection.Count == 0)
            {
                MessageNullCollection(true);
            }
            else 
            {
                MessageNullCollection(false);
            }
        }

        private void MessageNullCollection(bool values)
        {
            NullCollection = values;
            if (!values) { IsVisibleSearchPanel = "true"; }
            else { IsVisibleSearchPanel = "false"; }
        }

        private void SelectionSettingSearch(out ObservableCollection<BookModel> tmpResult , string textQuery)
        {
            if (SearchBy == "Названию")
            {
                tmpResult = new ObservableCollection<BookModel>(_bookCollection.Where(x => x.Name.Split(' ', ',').Any(word => word.ToLower() == textQuery.ToLower())));
            }
            else if (SearchBy == "Автору")
            {
                tmpResult = new ObservableCollection<BookModel>(_bookCollection.Where(x => x.Autor.Split(' ', ',', '.').Any(word => word.ToLower() == textQuery.ToLower())));
            }
            else
            {
                tmpResult = new ObservableCollection<BookModel>(_bookCollection.Where(x => x.Genre.Split(' ', ',').Any(word => word.ToLower() == textQuery.ToLower())));
            }
        }
    }
}
