using Business.Services;
using Data.ConnectDb;
using Data.Entities;
using Data.Repositories;

namespace AexSoftTest.Data.Tests
{
    public class BookRepositoryTests
    {
        private BookRepository _testRepository;
        private AutorRepository _autorRepository;
        private GanreRepository _ganreRepository;
        private StorageRepository _storageRepository;
        private CoverViewRepository _coverViewRepository;

        private Book _testItem;

        [SetUp]
        public void Setup()
        {
            ConnectSettings.RenameDatabaseUser("testuser");

            RestartDB();

            _testItem = new Book()
            {
                Autors = new Autor { Name = "С.Кинг" },
                Ganre = new Ganre { Name = "Роман" },
                Name = "Мобильник",
                Storage = new Storage { Rack = "12", Shelf = "2", Row = "3" }
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
                Autors = new Autor { Name = "Эрих Мария Ремарк" },
                Ganre = new Ganre { Name = "Роман" },
                Name = "Ночь в Лиссабоне",
                Storage = new Storage { Rack = "23", Shelf = "1", Row = "45" }
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
        }

        private void RestartDB()
        {
            _testRepository = new BookRepository();
            
            _testRepository.Droptable();
            _testRepository = new BookRepository();
            _autorRepository = new AutorRepository();
            _storageRepository = new StorageRepository();
            _ganreRepository = new GanreRepository();
            _coverViewRepository = new CoverViewRepository();
        }
    }
}
