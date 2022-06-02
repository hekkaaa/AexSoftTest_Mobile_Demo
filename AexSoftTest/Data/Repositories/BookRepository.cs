using Data.ConnectDb;
using Data.Entities;
using SQLite;
using SQLiteNetExtensions.Extensions;
using System.Collections.Generic;

namespace Data.Repositories
{
    public class BookRepository
    {
        private readonly SQLiteConnection database;

        public BookRepository()
        {
            database = new SQLiteConnection(ConnectSettings.PathDatabaseCollection);
            database.CreateTable<Book>();
        }

        public List<Book> GetBookAll()
        {
            return database.GetAllWithChildren<Book>();
        }

        public Book GetBookById(int id)
        {
            return database.GetWithChildren<Book>(id);
        }

        public int DeleteBook(int id)
        {
            return database.Delete<Book>(id);
        }

        public int AddBook(Book item)
        {
            database.Insert(item);
            return 1;
        }

        public int UpdateBook(Book item)
        {
            database.UpdateWithChildren(item);
            return item.Id;
        }

        public void Droptable()
        {
            database.DropTable<Book>();
            database.DropTable<Autor>();
            database.DropTable<Ganre>();
            database.DropTable<Storage>();
            database.DropTable<CoverView>();
        }


        public List<Book> SerchItem(string searchName)
        {
            string tmpSearchText = "%" + searchName + "%";
          
            var res = database.Query<Book>("select * FROM Book b JOIN Ganre g ON b.GanreId = g.Id " +
            $"JOIN Autor a ON b.AutorId = a.Id WHERE b.Name LIKE ?1 OR g.Name LIKE ?1 OR a.Name LIKE ?1 ", tmpSearchText);
            return res;
        }
    }
}
