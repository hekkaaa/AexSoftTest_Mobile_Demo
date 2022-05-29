using AexSoftTest.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AexSoftTest.ViewModels
{
    public class NewItemPageViewModel : INotifyPropertyChanged
    {
        private BookPageViewModel _bookViewModel;
        private BookModel _bookModel;

        public NewItemPageViewModel(BookPageViewModel bookViewModel)
        {
            _bookViewModel = bookViewModel;
            _bookModel = new BookModel();
        }

        public NewItemPageViewModel(BookPageViewModel bookViewModel, BookModel bookModel)
        {
            _bookViewModel = bookViewModel;
            _bookModel = bookModel;
        }

        public BookPageViewModel BookViewModel { 

            get { return _bookViewModel; } 
            set {
               
                _bookViewModel = value; 
                OnPropertyChanged("BookViewModel"); 
            }
        }

        public BookModel BookItem
        {
            get { return _bookModel; }
           
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
