using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AexSoftTest.Models
{
    public abstract class PrintEdition : INotifyPropertyChanged
    {
        private int _id;
        private string _name;
        private string _genre;
        private string _autor;
        private string _coverView;
        private string _row;
        private string _rack;
        private string _shelf;

        public int Id { get { return _id; } set { _id = value; OnPropertyChanged("Id"); } }
        public string Name { get { return _name; } set { _name = value; OnPropertyChanged("Name"); } }
        public string Genre { get { return _genre; } set { _genre = value; OnPropertyChanged("Genre"); } }
        public string Autor { get { return _autor; } set { _autor = value; OnPropertyChanged("Autor"); } }
        public string CoverView { get { return _coverView; } set { _coverView = value; OnPropertyChanged("CoverView"); } }

        public string Row { get { return _row; } set { _row = value; OnPropertyChanged("Row"); } }
        public string Rack { get { return _rack; } set { _rack = value; OnPropertyChanged("Rack"); } }
        public string Shelf { get { return _shelf; } set { _shelf = value; OnPropertyChanged("Shelf"); } }
     

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
