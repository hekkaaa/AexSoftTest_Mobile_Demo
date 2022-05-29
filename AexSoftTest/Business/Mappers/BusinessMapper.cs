using Business.Models;
using Data.Entities;
using System.Collections.Generic;

namespace Business.Mappers
{
    public class BusinessMapper
    {
        public BookBusinessModel MapFromBook(Book oldItem)
        {
            BookBusinessModel newItem = new BookBusinessModel
            {
                Id = oldItem.Id,
                Name = oldItem.Name,
                Autor = oldItem.Autor,
                CoverView = oldItem.CoverView,
                Shelf = oldItem.Shelf,
                Genre = oldItem.Genre,
                Rack = oldItem.Rack,
                Row = oldItem.Row
            };

            return newItem;
        }

        public List<BookBusinessModel> MapFromListBook(List<Book> oldListItem)
        {
            List<BookBusinessModel> newListItem = new List<BookBusinessModel>();

            foreach (Book book in oldListItem)
            {
                newListItem.Add(MapFromBook(book));
            }
            return newListItem;
        }

        public Book MapInBook(BookBusinessModel oldItem)
        {
            Book newItem = new Book
            {
                Name = oldItem.Name,
                Autor = oldItem.Autor,
                CoverView = oldItem.CoverView,
                Shelf = oldItem.Shelf,
                Genre = oldItem.Genre,
                Id = oldItem.Id,
                Rack = oldItem.Rack,
                Row = oldItem.Row
            };

            return newItem;
        }

        public List<Book> MapFromListBook(List<BookBusinessModel> oldListItem)
        {
            List<Book> newListItem = new List<Book>();

            foreach (BookBusinessModel book in oldListItem)
            {
                newListItem.Add(MapInBook(book));
            }
            return newListItem;
        }
    }
}
