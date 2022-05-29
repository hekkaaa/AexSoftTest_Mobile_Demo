using Data.ConnectDb;
using Data.Entities;
using SQLite;
using System.Collections.Generic;

namespace Data.Repositories
{
    public class BookRepository
    {
        SQLiteConnection database;

        public BookRepository()
        {
            database = new SQLiteConnection(ConnectSettings.PathDatabase);
            database.CreateTable<Book>();
        }

        public List<Book> GetBookAll()
        {
            return database.Table<Book>().ToList();
        }

        public Book GetBookById(int id)
        {
            return database.Get<Book>(id);
        }

        public int DeleteBook(int id)
        {
            return database.Delete<Book>(id);
        }

        public int AddBook(Book item)
        {
            return database.Insert(item);
        }

        public int UpdateBook(Book item)
        {
            database.Update(item);
            return item.Id;
        }

        public void Droptable()
        {
            database.DropTable<Book>();
        }
    }
}
