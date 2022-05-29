using AexSoftTest.Models;
using Business.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AexSoftTest.Mappers
{
    public class Mapper
    {
        public BookModel MapFromBookBusinessModel(BookBusinessModel oldItem)
        {
            BookModel newItem = new BookModel()
            {
                Name = oldItem.Name,
                Autor = oldItem.Autor,
                CoverView = oldItem.CoverView,
                Shelf = oldItem.Shelf,
                Genre = oldItem.Shelf,
                Id = oldItem.Id,
                Rack = oldItem.Rack,
                Row = oldItem.Row
            };

            return newItem;
        }

        public ObservableCollection<BookModel> MapFromListBookBusinessModel(List<BookBusinessModel> oldListItem)
        {
            ObservableCollection<BookModel> newListItem = new ObservableCollection<BookModel>();

            foreach (Business.Models.BookBusinessModel item in oldListItem)
            {
                newListItem.Add(MapFromBookBusinessModel(item));
            }

            return newListItem;
        }

        public BookBusinessModel MapInBookBusinessModel(BookModel oldItem)
        {
            BookBusinessModel newItem = new BookBusinessModel()
            {
                Name = oldItem.Name,
                Autor = oldItem.Autor,
                CoverView = oldItem.CoverView,
                Shelf = oldItem.Shelf,
                Genre = oldItem.Shelf,
                Id = oldItem.Id,
                Rack = oldItem.Rack,
                Row = oldItem.Row
            };

            return newItem;
        }


        public List<BookBusinessModel> MapInListBookBusinessModel(ObservableCollection<BookModel> oldListItem)
        {
            List<BookBusinessModel> newListItem = new List<BookBusinessModel>();

            foreach (BookModel item in oldListItem)
            {
                newListItem.Add(MapInBookBusinessModel(item));
            }
            return newListItem;
        }
    }
}
