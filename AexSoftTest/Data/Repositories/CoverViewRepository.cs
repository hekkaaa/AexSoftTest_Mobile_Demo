using Data.ConnectDb;
using Data.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public class CoverViewRepository
    {
        private readonly SQLiteConnection database;

        public CoverViewRepository()
        {
            database = new SQLiteConnection(ConnectSettings.PathDatabaseCollection);
            database.CreateTable<CoverView>();
        }

        public int AddCoverView(CoverView item)
        {
            return database.Insert(item);
        }

        public int UpdateCoverView(CoverView item)
        {
            return database.Update(item);
        }
    }
}
