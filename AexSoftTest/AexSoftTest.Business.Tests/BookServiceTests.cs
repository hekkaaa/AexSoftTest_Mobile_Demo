using Business.Models;
using Business.Services;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AexSoftTest.Business.Tests
{
    public class BookServiceTests
    {
        private BookService _testBookService;
        private BookRepository _testBookRepository;
        private BookBusinessModel _testItem;
        private AutorRepository _autorRepository;
        private GanreRepository _ganreRepository;
        private StorageRepository _storageRepository;
        private CoverViewRepository _coverViewRepository;

        [SetUp]
        public void Setup()
        {
            _testBookService = new BookService();
            RestartDB();

            _testItem = new BookBusinessModel()
            {
                Autor = "Эрих Мария Ремарк",
                Name = "Ночь в Лиссабоне",
                Genre = "Роман",
                Shelf = "12",
                Rack = "1",
                Row = "2"
            };
        }

        [Test]
        public void GetBookByIdTest_WhenAddBookIsTrue()
        {
            //given
            int expectedId = 1; // Successful execution
            BookBusinessModel expected = _testItem;
            _testBookService.AddBook(_testItem);

            ////when
            BookBusinessModel actual = _testBookService.GetBookById(expectedId);

            ////then 
            Assert.NotNull(actual);
            Assert.AreEqual(expectedId, actual.Id);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Genre, actual.Genre);
            Assert.AreEqual(expected.Shelf, actual.Shelf);
            Assert.AreEqual(expected.Row, actual.Row);
            Assert.AreEqual(expected.Autor, actual.Autor);
            Assert.AreEqual(expected.Rack, actual.Rack);
        }

        [Test]
        public void GetBookByIdTest_WhenAddBookIsFalse()
        {
            //given
            int expectedId = 2; // Successful execution
            _testBookService.AddBook(_testItem);

            ////when

            ////then 
            Assert.Throws<ArgumentException>(() => _testBookService.GetBookById(expectedId));
        }

        [Test]
        public void GetBookAllTest_WhenAddListBookIsTrue()
        {
            //given
            int expectedId = 2; //  Number of objects in the database
            _testBookService.AddBook(_testItem);
            _testBookService.AddBook(_testItem);

            ////when
            List<BookBusinessModel> actual = _testBookService.GetBookAll();

            ////then 
            Assert.NotNull(actual);
            Assert.AreEqual(expectedId, actual.Count);
        }

        [Test]
        public void GetBookAllTest_WhenAddListBookIsFalse()
        {
            //given
            int expectedId = 0; //  Number of objects in the database

            ////when
            List<BookBusinessModel> actual = _testBookService.GetBookAll();

            ////then 
            Assert.NotNull(actual);
            Assert.AreEqual(expectedId, actual.Count);
        }


        [Test]
        public void DeleteBookTest_WhenDeleteBookIsTrue()
        {
            //given
            int expectedId = 1; // Successful execution
            _testBookService.AddBook(_testItem);

            ////when
            bool actual = _testBookService.DeleteBook(expectedId);

            ////then 
            Assert.NotNull(actual);
            Assert.IsTrue(actual);
        }

        [Test]
        public void DeleteBookTest_WhenDeleteBookIsFalse()
        {
            //given
            int expectedId = 2; // Successful execution
            _testBookService.AddBook(_testItem);

            ////when
            bool actual = _testBookService.DeleteBook(expectedId);

            ////then 
            Assert.NotNull(actual);
            Assert.IsFalse(actual);
        }

        [Test]
        public void AddUserTest_WhenAddBookIsTrue()
        {
            //given
            _testBookService.AddBook(_testItem);

            ////when
            bool actual = _testBookService.AddBook(_testItem);

            ////then 
            Assert.NotNull(actual);
            Assert.IsTrue(actual);
        }

        [Test]
        public void UpdateBookTest_WhenUpdateBookIsTrue()
        {
            //given
            _testBookService.AddBook(_testItem);
            var expected = _testBookService.GetBookById(1);

            expected.Autor = "Стивен Кинг";
            expected.Name = "Мобильник";
            expected.Genre = "Роман";
            expected.Shelf = "1";
            expected.Rack = "7";
            expected.Row = "90";


            ////when
            bool actual = _testBookService.UpdateBook(expected);
            var postActual = _testBookService.GetBookById(expected.Id);

            ////then 
            Assert.NotNull(actual);
            Assert.IsTrue(actual);
            Assert.AreEqual(expected.Id, postActual.Id);
            Assert.AreEqual(expected.Name, postActual.Name);
            Assert.AreEqual(expected.Genre, postActual.Genre);
            Assert.AreEqual(expected.Shelf, postActual.Shelf);
            Assert.AreEqual(expected.Row, postActual.Row);
            Assert.AreEqual(expected.Autor, postActual.Autor);
            Assert.AreEqual(expected.Rack, postActual.Rack);
        }

        private void RestartDB()
        {
            _testBookRepository = new BookRepository();
            _testBookRepository.Droptable();
            _testBookRepository = new BookRepository();
            _autorRepository = new AutorRepository();
            _storageRepository = new StorageRepository();
            _ganreRepository = new GanreRepository();
            _coverViewRepository = new CoverViewRepository();
        }
    }
}
