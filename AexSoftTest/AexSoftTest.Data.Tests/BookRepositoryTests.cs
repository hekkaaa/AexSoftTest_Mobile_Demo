using Data.ConnectDb;
using Data.Entities;
using Data.Repositories;

namespace AexSoftTest.Data.Tests
{
    public class BookRepositoryTests
    {
        private BookRepository _testRepository;
        private Book _testItem;

        [SetUp]
        public void Setup()
        {
            _testRepository = new BookRepository();
            ConnectSettings.RenameDatabaseUser("testuser");
            RestartDB();

            _testItem = new Book()
            {
                Autor = "С.Кинг",
                Genre = "Роман",
                Name = "Мобильник",
                Rack = "12",
                Shelf = "2",
                Row = "3"
            };
        }

        [Test]
        public void AddBookTest()
        {
            //given
            int expected = 1; // Successful execution

            ////when
            int actual = _testRepository.AddBook(_testItem);

            ////then 
            Assert.NotNull(actual);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void UpdateBookTest()
        {
            //given
            Book expected = new Book()
            {
                Id = 1,
                Autor = "Эрих Мария Ремарк",
                Genre = "Роман",
                Name = "Ночь в Лиссабоне",
                Rack = "23",
                Shelf = "1",
                Row = "45"
            };

            int successUpdate = 1; // Successful execution

            ////when
            _testRepository.AddBook(_testItem);
            int actual = _testRepository.UpdateBook(expected);
            Book postActual = _testRepository.GetBookById(_testItem.Id);

            ////then 
            Assert.NotNull(actual);
            Assert.That(actual, Is.EqualTo(successUpdate));
            Assert.AreEqual(expected.Id, postActual.Id);
            Assert.AreEqual(expected.Name, postActual.Name);
            Assert.AreEqual(expected.Genre, postActual.Genre);
            Assert.AreEqual(expected.Rack, postActual.Rack);
            Assert.AreEqual(expected.Row, postActual.Row);
            Assert.AreEqual(expected.Shelf, postActual.Shelf);
            Assert.AreEqual(expected.Autor, postActual.Autor);
        }

        [Test]
        public void DeleteBookTest()
        {
            //given
            int expected = 1; // Successful execution
            int postExpected = 0; // Number of objects in the database after deletion

            ////when
            _testRepository.AddBook(_testItem);
            int actual = _testRepository.DeleteBook(expected);
            var postActual = _testRepository.GetBookAll();

            ////then 
            Assert.NotNull(actual);
            Assert.That(actual, Is.EqualTo(expected));
            Assert.AreEqual(postExpected, postActual.Count);

        }

        [Test]
        public void GetBookAllTest()
        {
            //given
            int expected = 2; // Number of objects in the database

            ////when
            _testRepository.AddBook(_testItem);
            _testRepository.AddBook(_testItem);
            var actual = _testRepository.GetBookAll();


            ////then 
            Assert.NotNull(actual);
            Assert.That(actual.Count, Is.EqualTo(expected));
        }

        [Test]
        public void GetBookByIdTest()
        {
            //given
            var expected = _testItem;
            int idNewBook = 1;

            ////when
            _testRepository.AddBook(_testItem);
            Book actual = _testRepository.GetBookById(idNewBook);

            ////then 
            Assert.NotNull(actual);
            Assert.AreEqual(idNewBook, actual.Id);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Genre, actual.Genre);
            Assert.AreEqual(expected.Autor, actual.Autor);
            Assert.AreEqual(expected.Row, actual.Row);
            Assert.AreEqual(expected.Rack, actual.Rack);
            Assert.AreEqual(expected.Shelf, actual.Shelf);
        }

        private void RestartDB()
        {
            _testRepository = new BookRepository();
            _testRepository.Droptable();
            _testRepository = new BookRepository();
        }
    }
}
