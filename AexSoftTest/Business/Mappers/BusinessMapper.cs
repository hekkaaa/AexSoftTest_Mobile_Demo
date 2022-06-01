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
                AutorId = oldItem.AutorId,
                Autor = oldItem.Autors.Name,
                CoverViewId = oldItem.CoverViewId,
                CoverView = oldItem.CoverView.Path,
                GenreId = oldItem.GanreId,
                Genre = oldItem.Ganre.Name,
                Storageid = oldItem.StorageId,
                Shelf = oldItem.Storage.Shelf,
                Rack = oldItem.Storage.Rack,
                Row = oldItem.Storage.Row
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
                Id = oldItem.Id,
                Name = oldItem.Name,
                Autors = new Autor { Id = oldItem.AutorId, Name = oldItem.Autor },
                CoverView = new CoverView { Id = oldItem.CoverViewId, Path = oldItem.CoverView },
                Ganre = new Ganre { Id = oldItem.GenreId, Name = oldItem.Genre },
                Storage = new Storage { Id = oldItem.Storageid, Rack = oldItem.Rack, Row = oldItem.Row, Shelf = oldItem.Shelf },
                AutorId = oldItem.AutorId,
                CoverViewId = oldItem.CoverViewId,
                StorageId = oldItem.Storageid,
                GanreId = oldItem.GenreId
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
