using Data.ConnectDb;
using Data.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public class AutorRepository
    {
        private readonly SQLiteConnection database;

        public AutorRepository()
        {
            database = new SQLiteConnection(ConnectSettings.PathDatabaseCollection);
            database.CreateTable<Autor>();
          
        }

        public int AddAutor(Autor item)
        {
            return database.Insert(item);
        }

        public Autor GetAutorById(int id)
        {
            return database.Get<Autor>(id);
        }

        public int UpdateAutor(Autor item)
        {
            return database.Update(item);
        }
    }
}
