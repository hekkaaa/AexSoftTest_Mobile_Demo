using Business.Mappers;
using Business.Models;
using Data.Entities;
using Data.Repositories;
using System;
using System.Collections.Generic;

namespace Business.Services
{
    public class BookService
    {
        private readonly AutorRepository _autorRepository;
        private readonly BookRepository _bookRepository;
        private readonly GanreRepository _ganreRepository;
        private readonly StorageRepository _storageRepository;
        private readonly CoverViewRepository _coverViewRepository;
        private readonly BusinessMapper _mapper;

        public BookService()
        {
            _bookRepository = new BookRepository();
            _autorRepository = new AutorRepository();
            _storageRepository = new StorageRepository();
            _ganreRepository = new GanreRepository();
            _coverViewRepository = new CoverViewRepository();
            _mapper = new BusinessMapper();
        }

        public BookBusinessModel GetBookById(int id)
        {
            try
            {
                Book res = _bookRepository.GetBookById(id);
                return _mapper.MapFromBook(res);
            }
            catch (InvalidOperationException)
            {
                throw new ArgumentException("Нет данных по указанному id");
            }
        }

        public List<BookBusinessModel> GetBookAll()
        {
            List<Book> res = _bookRepository.GetBookAll();
            return _mapper.MapFromListBook(res);
        }

        public bool DeleteBook(int id)
        {
            var res = _bookRepository.DeleteBook(id);

            if (res == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool AddBook(BookBusinessModel newitem)
        {
            if (newitem.CoverView == null) newitem.CoverView = "defaultbook.jpg";

            Autor tmpAutor = new Autor { Name = newitem.Autor };
            Storage tmpStorage = new Storage { Rack = newitem.Rack, Row = newitem.Row, Shelf = newitem.Shelf };
            Ganre tmpGanre = new Ganre { Name = newitem.Genre };
            CoverView tmpCoverView = new CoverView { Path = newitem.CoverView };

            _autorRepository.AddAutor(tmpAutor);
            _storageRepository.AddStorage(tmpStorage);
            _ganreRepository.AddGanre(tmpGanre);
            _coverViewRepository.AddCoverView(tmpCoverView);

            var tmpItem = _mapper.MapInBook(newitem);
            int res = _bookRepository.AddBook(tmpItem);

            if (res == 0)
            {
                return false;
            }
            else
            {
                tmpItem.Storage = tmpStorage;
                tmpItem.Autors = tmpAutor;
                tmpItem.CoverView = tmpCoverView;
                tmpItem.Ganre = tmpGanre;

                _bookRepository.UpdateBook(tmpItem);

                return true;
            }
        }

        public bool UpdateBook(BookBusinessModel updateItem)
        {
            BookBusinessModel tmpBusinessBook = _mapper.MapFromBook(_bookRepository.GetBookById(updateItem.Id));

            tmpBusinessBook.Name = updateItem.Name;
            tmpBusinessBook.Autor = updateItem.Autor;
            tmpBusinessBook.Genre = updateItem.Genre;
            tmpBusinessBook.CoverView = updateItem.CoverView;
            tmpBusinessBook.Shelf = updateItem.Shelf;
            tmpBusinessBook.Rack = updateItem.Rack;
            tmpBusinessBook.Row = updateItem.Row;

            Book tmpBook = _mapper.MapInBook(tmpBusinessBook);

            _autorRepository.UpdateAutor(tmpBook.Autors);
            _ganreRepository.UpdateGanre(tmpBook.Ganre);
            _coverViewRepository.UpdateCoverView(tmpBook.CoverView);
            _storageRepository.UpdateStorage(tmpBook.Storage);

            var res = _bookRepository.UpdateBook(tmpBook);
            if (res == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<BookBusinessModel> SearchItem(string searchName)
        {
            var tmpCollection = _bookRepository.SerchItem(searchName);
            List<BookBusinessModel> resultList = new List<BookBusinessModel>();

            foreach (Book item in tmpCollection)
            {
                BookBusinessModel mapItem = _mapper.MapFromBook(_bookRepository.GetBookById(item.Id));
                resultList.Add(mapItem);
            }
            return resultList;
        }

        public void Droptable()
        {
            // для тестовых сбросов таблиц.
            _bookRepository.Droptable();
        }

    }
}
