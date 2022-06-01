using Data.ConnectDb;
using Data.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public class StorageRepository
    {
        private readonly SQLiteConnection database;

        public StorageRepository()
        {
            database = new SQLiteConnection(ConnectSettings.PathDatabaseCollection);
            database.CreateTable<Storage>();

        }

        public int AddStorage(Storage item)
        {
            return database.Insert(item);
        }

        public int UpdateStorage(Storage item)
        {
            return database.Update(item);
        }
    }
}
