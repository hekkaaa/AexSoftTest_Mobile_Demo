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
        private readonly BookRepository _bookRepository;
        private readonly BusinessMapper _mapper;

        public BookService()
        {
            _bookRepository = new BookRepository();
            _mapper = new BusinessMapper();
        }

        public BookBusinessModel GetBookById(int id)
        {
            Book res = _bookRepository.GetBookById(id);

            if (res == null)
            {
                throw new ArgumentException("Нет данных по указанному id");
            }
            else
            {
                return _mapper.MapFromBook(res);
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
            
            int res = _bookRepository.AddBook(_mapper.MapInBook(newitem));

            if (res == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool UpdateBook(BookBusinessModel updateItem)
        {
            var res = _bookRepository.UpdateBook(_mapper.MapInBook(updateItem));
            if (res == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Droptable()
        {
            // для тестовых сбросов таблиц.
            _bookRepository.Droptable();
        }

    }
}
